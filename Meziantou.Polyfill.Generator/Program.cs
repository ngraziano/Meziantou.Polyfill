﻿using System.Reflection;
using System.Text;
using Meziantou.Polyfill.Generator;

var assembly = Assembly.GetExecutingAssembly();
var polyfills = assembly.GetManifestResourceNames()
      .OrderBy(_ => _, StringComparer.Ordinal)
      .Select((item, index) =>
      {
          var typeName = Path.GetFileNameWithoutExtension(item).Replace(';', ':');
          return new Polyfill()
          {
              Index = index,
              TypeName = typeName,
              OutputPath = Path.GetFileNameWithoutExtension(item)
                               .Replace(';', '_')
                               .Replace('@', '_') + ".g.cs",
              CSharpName = Path.GetFileNameWithoutExtension(item)
                               .Replace(';', '_')
                               .Replace('@', '_')
                               .Replace('{', '_')
                               .Replace('}', '_')
                               .Replace('(', '_')
                               .Replace(')', '_')
                               .Replace(',', '_')
                               .Replace('.', '_')
                               .Replace('`', '_'),
              PolyfillData = PolyfillData.Get($$""""
                  // <auto-generated/>
                  #pragma warning disable
                  #nullable enable annotations
                  {{ReadResourceAsString(item)}}
                  """"),
          };
      })
      .OrderBy(_ => _.PolyfillData.ConditionalMembers.Length == 0 ? 0 : 1) // Should be a topological sort to be correct, but it's enough at the moment
      .ThenBy(_ => _.Index)
      .ToArray();

polyfills = SortPolyfills(polyfills);

var fieldCount = (polyfills.Length / 64) + (polyfills.Length % 64 > 0 ? 1 : 0);

var sb = new StringBuilder();
sb.AppendLine($$"""
    // Polyfills: {{polyfills.Length}}
    #nullable enable
    using System;
    using System.Text;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.Text;

    namespace Meziantou.Polyfill;

    internal readonly partial struct Members : IEquatable<Members>
    {
    """);

for (var i = 0; i < fieldCount; i++)
{
    sb.AppendLine($"private readonly ulong _bits{i} = 0uL;");
}

sb.AppendLine($"private readonly PolyfillOptions _options;");
sb.AppendLine($"private readonly string[]? _excludedMembers;");
sb.AppendLine($"private readonly bool _hasSpanOfT;");
sb.AppendLine($"private readonly bool _hasReadOnlySpanOfT;");
sb.AppendLine($"private readonly bool _hasMemoryOfT;");
sb.AppendLine($"private readonly bool _hasReadOnlyMemoryOfT;");
sb.AppendLine($"private readonly bool _hasValueTask;");
sb.AppendLine($"private readonly bool _hasValueTaskOfT;");

sb.AppendLine("public Members(Compilation compilation, PolyfillOptions options)");
sb.AppendLine("{");
sb.AppendLine("    _options = options;");

if (polyfills.Any(p => p.PolyfillData.RequiresSpanOfT))
    sb.AppendLine("    _hasSpanOfT = compilation.GetTypeByMetadataName(\"System.Span`1\") != null;");
if (polyfills.Any(p => p.PolyfillData.RequiresReadOnlySpanOfT))
    sb.AppendLine("    _hasReadOnlySpanOfT = compilation.GetTypeByMetadataName(\"System.ReadOnlySpan`1\") != null;");
if (polyfills.Any(p => p.PolyfillData.RequiresMemory))
    sb.AppendLine("    _hasMemoryOfT = compilation.GetTypeByMetadataName(\"System.Memory`1\") != null;");
if (polyfills.Any(p => p.PolyfillData.RequiresReadOnlyMemory))
    sb.AppendLine("    _hasReadOnlyMemoryOfT = compilation.GetTypeByMetadataName(\"System.ReadOnlyMemory`1\") != null;");
if (polyfills.Any(p => p.PolyfillData.RequiresValueTask))
    sb.AppendLine("    _hasValueTask = compilation.GetTypeByMetadataName(\"System.Threading.Tasks.ValueTask\") != null;");
if (polyfills.Any(p => p.PolyfillData.RequiresValueTaskOfT))
    sb.AppendLine("    _hasValueTaskOfT = compilation.GetTypeByMetadataName(\"System.Threading.Tasks.ValueTask`1\") != null;");

foreach (var polyfill in polyfills)
{
    sb.AppendLine($"    if ({GenerateIncludeCondition(polyfill.PolyfillData)}IncludeMember(compilation, options, \"{polyfill.TypeName}\"))");
    sb.AppendLine($"        {polyfill.CSharpFieldName} = {polyfill.CSharpFieldName} | {polyfill.CSharpFieldBitMask}uL;");

    string GenerateIncludeCondition(PolyfillData data)
    {
        var result = "";
        if (data.RequiresSpanOfT)
            result += "_hasSpanOfT && ";
        if (data.RequiresReadOnlySpanOfT)
            result += "_hasReadOnlySpanOfT && ";
        if (data.RequiresMemory)
            result += "_hasMemoryOfT && ";
        if (data.RequiresReadOnlyMemory)
            result += "_hasReadOnlyMemoryOfT && ";
        if (data.RequiresValueTask)
            result += "_hasValueTask && ";
        if (data.RequiresValueTaskOfT)
            result += "_hasValueTaskOfT && ";

        if (data.ConditionalMembers.Length > 0)
        {
            result += "(";
            result += string.Join(" || ", data.ConditionalMembers.Select(member =>
            {
                var dependency = polyfills.Single(p => p.TypeName == member);
                return $"({dependency.CSharpFieldName} & {dependency.CSharpFieldBitMask}ul) == {dependency.CSharpFieldBitMask}ul";
            }));
            result += ") && ";
        }
        return result;
    }
}
sb.AppendLine("}");



sb.AppendLine("public override int GetHashCode()");
sb.AppendLine("{");
sb.AppendLine("    var hash = _bits0.GetHashCode();");
for (var i = 1; i < fieldCount; i++)
{
    sb.AppendLine($"    hash = hash * 23 + _bits{i}.GetHashCode();");
}

sb.AppendLine("    return hash;");
sb.AppendLine("}");



sb.AppendLine("public override bool Equals(object? obj) => obj is Members other && Equals(other);");
sb.Append("public bool Equals(Members other) => _bits0 == other._bits0");
for (var i = 1; i < fieldCount; i++)
{
    sb.Append($"  && _bits{i} == other._bits{i}");
}
sb.AppendLine(";");


sb.AppendLine("public void AddSources(SourceProductionContext context)");
sb.AppendLine("{");
foreach (var polyfill in polyfills)
{
    sb.AppendLine($"    if (({polyfill.CSharpFieldName} & {polyfill.CSharpFieldBitMask}ul) == {polyfill.CSharpFieldBitMask}ul)");
    sb.AppendLine($"        context.AddSource(\"{polyfill.OutputPath}\", PolyfillContents.{polyfill.CSharpSourceTextPropertyName});");
}
sb.AppendLine("}");

sb.AppendLine("public string DumpAsCSharpComment()");
sb.AppendLine("{");
sb.AppendLine("    var sb = new StringBuilder();");
sb.AppendLine("    sb.AppendLine(_options.DumpAsCSharpComment());");
sb.AppendLine("    sb.AppendLine(\"// HasMemoryOfT: \" + _hasMemoryOfT);");
sb.AppendLine("    sb.AppendLine(\"// HasReadOnlyMemoryOfT: \" + _hasReadOnlyMemoryOfT);");
sb.AppendLine("    sb.AppendLine(\"// HasReadOnlySpanOfT: \" + _hasReadOnlySpanOfT);");
sb.AppendLine("    sb.AppendLine(\"// HasSpanOfT: \" + _hasSpanOfT);");
sb.AppendLine("    sb.AppendLine(\"// HasValueTask: \" + _hasValueTask);");
sb.AppendLine("    sb.AppendLine(\"// HasValueTaskOfT: \" + _hasValueTaskOfT);");
sb.AppendLine("    sb.AppendLine(\"//\");");
foreach (var polyfill in polyfills)
{
    sb.AppendLine($"    sb.AppendLine(\"// {polyfill.TypeName}: \" + (({polyfill.CSharpFieldName} & {polyfill.CSharpFieldBitMask}ul) == {polyfill.CSharpFieldBitMask}ul));");
}

sb.AppendLine("    return sb.ToString();");
sb.AppendLine("}");

sb.AppendLine("}");

sb.AppendLine("file static class PolyfillContents");
sb.AppendLine("{");
foreach (var polyfill in polyfills)
{
    sb.AppendLine($"public static SourceText {polyfill.CSharpSourceTextPropertyName} {{ get; }} = SourceText.From(\"\"\"\"\"\"\"\"\"\"");
    sb.AppendLine(polyfill.PolyfillData.Content);
    sb.AppendLine("\"\"\"\"\"\"\"\"\"\", Encoding.UTF8);");
}
sb.AppendLine("}");

Console.WriteLine(sb.ToString());
var path = Path.GetFullPath("../../../../Meziantou.Polyfill/Members.g.cs");
Console.WriteLine(path);
File.WriteAllText(path, sb.ToString());


string ReadResourceAsString(string name)
{
    using var sr = new StreamReader(assembly.GetManifestResourceStream(name)!);
    return sr.ReadToEnd();
}

static Polyfill[] SortPolyfills(Polyfill[] items)
{
    var result = new List<Polyfill>(items.Length);
    var remainingItems = items.ToList();
    while (remainingItems.Count > 0)
    {
        foreach (var item in remainingItems.Where(CanAddItem).OrderBy(i => i.Index).ToList())
        {
            result.Add(item);
            remainingItems.Remove(item);
        }
    }

    return result.ToArray();

    bool CanAddItem(Polyfill polyfill)
    {
        if (polyfill.PolyfillData.ConditionalMembers.Length == 0)
            return true;

        if (polyfill.PolyfillData.ConditionalMembers.All(m => result.Find(i => i.TypeName == m) != null))
            return true;

        return false;
    }
}

sealed class Polyfill
{
    public required int Index { get; set; }
    public required string TypeName { get; set; }
    public required string CSharpName { get; set; }
    public required PolyfillData PolyfillData { get; set; }
    public required string OutputPath { get; set; }

    public string CSharpFieldName => "_bits" + (Index / 64);
    public int CSharpFieldBitIndex => Index % 64;
    public ulong CSharpFieldBitMask => 1uL << (Index % 64);
    public string CSharpSourceTextPropertyName => "Source_" + CSharpName;

    public override string ToString()
    {
        return TypeName;
    }
}