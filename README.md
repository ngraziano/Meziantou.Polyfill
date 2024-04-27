# Meziantou.Polyfill

[![NuGet](https://img.shields.io/nuget/v/Meziantou.Polyfill.svg)](https://www.nuget.org/packages/Meziantou.Polyfill/)

Source Generator that adds polyfill methods and types. This helps working with multi-targeted projects.

Read more about the project: [Polyfills in .NET to ease multi-targeting](https://www.meziantou.net/polyfills-in-dotnet-to-ease-multi-targeting.htm)

## Installation

````bash
dotnet add package Meziantou.Polyfill
````

Then, you should see the generated types in the solution explorer

![Generated files in the Visual Studio's Solution Explorer](docs/solutionexplorer-polyfill.png)

## Customization

By default, all needed polyfills are generated. You can configure which polyfills should be generated by editing the `.csproj` file and adding the following properties:

````xml
<PropertyGroup>
  <!-- semicolon-separated or pipe-separated list of name prefix -->
  <!-- Tip: The name of the generated polyfills are available in the generated "Debug.g.cs" file -->
  <MeziantouPolyfill_IncludedPolyfills>T:Type1|T:Type2|M:Member1</MeziantouPolyfill_IncludedPolyfills>
  <MeziantouPolyfill_ExcludedPolyfills>M:System.Diagnostics.</MeziantouPolyfill_ExcludedPolyfills>

  <!-- Optional: Output the generated files to the obj\GeneratedFiles folder  -->
  <EmitCompilerGeneratedFiles>True</EmitCompilerGeneratedFiles>
  <CompilerGeneratedFilesOutputPath>$(BaseIntermediateOutputPath)\GeneratedFiles</CompilerGeneratedFilesOutputPath>
</PropertyGroup>
````

## Supported polyfills

<!-- begin_polyfills -->

### Types

- `System.Collections.Generic.PriorityQueue<TElement, TPriority>`
- `System.Collections.Generic.ReferenceEqualityComparer`
- `System.Diagnostics.CodeAnalysis.AllowNullAttribute`
- `System.Diagnostics.CodeAnalysis.DisallowNullAttribute`
- `System.Diagnostics.CodeAnalysis.DoesNotReturnAttribute`
- `System.Diagnostics.CodeAnalysis.DoesNotReturnIfAttribute`
- `System.Diagnostics.CodeAnalysis.DynamicDependencyAttribute`
- `System.Diagnostics.CodeAnalysis.DynamicallyAccessedMemberTypes`
- `System.Diagnostics.CodeAnalysis.DynamicallyAccessedMembersAttribute`
- `System.Diagnostics.CodeAnalysis.ExperimentalAttribute`
- `System.Diagnostics.CodeAnalysis.MaybeNullAttribute`
- `System.Diagnostics.CodeAnalysis.MaybeNullWhenAttribute`
- `System.Diagnostics.CodeAnalysis.MemberNotNullAttribute`
- `System.Diagnostics.CodeAnalysis.MemberNotNullWhenAttribute`
- `System.Diagnostics.CodeAnalysis.NotNullAttribute`
- `System.Diagnostics.CodeAnalysis.NotNullIfNotNullAttribute`
- `System.Diagnostics.CodeAnalysis.NotNullWhenAttribute`
- `System.Diagnostics.CodeAnalysis.RequiresAssemblyFilesAttribute`
- `System.Diagnostics.CodeAnalysis.RequiresDynamicCodeAttribute`
- `System.Diagnostics.CodeAnalysis.RequiresUnreferencedCodeAttribute`
- `System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute`
- `System.Diagnostics.CodeAnalysis.StringSyntaxAttribute`
- `System.Diagnostics.CodeAnalysis.UnconditionalSuppressMessageAttribute`
- `System.Diagnostics.CodeAnalysis.UnscopedRefAttribute`
- `System.Diagnostics.StackTraceHiddenAttribute`
- `System.HashCode`
- `System.Index`
- `System.Net.Http.ReadOnlyMemoryContent`
- `System.Range`
- `System.Runtime.CompilerServices.AsyncMethodBuilderAttribute`
- `System.Runtime.CompilerServices.CallerArgumentExpressionAttribute`
- `System.Runtime.CompilerServices.CollectionBuilderAttribute`
- `System.Runtime.CompilerServices.CompilerFeatureRequiredAttribute`
- `System.Runtime.CompilerServices.DisableRuntimeMarshallingAttribute`
- `System.Runtime.CompilerServices.InterpolatedStringHandlerArgumentAttribute`
- `System.Runtime.CompilerServices.InterpolatedStringHandlerAttribute`
- `System.Runtime.CompilerServices.IsExternalInit`
- `System.Runtime.CompilerServices.ModuleInitializerAttribute`
- `System.Runtime.CompilerServices.RequiredMemberAttribute`
- `System.Runtime.CompilerServices.SkipLocalsInitAttribute`
- `System.Runtime.CompilerServices.TupleElementNamesAttribute`
- `System.Runtime.InteropServices.SuppressGCTransitionAttribute`
- `System.Runtime.InteropServices.UnmanagedCallersOnlyAttribute`
- `System.Runtime.Versioning.ObsoletedOSPlatformAttribute`
- `System.Runtime.Versioning.RequiresPreviewFeaturesAttribute`
- `System.Runtime.Versioning.SupportedOSPlatformAttribute`
- `System.Runtime.Versioning.SupportedOSPlatformGuardAttribute`
- `System.Runtime.Versioning.TargetPlatformAttribute`
- `System.Runtime.Versioning.UnsupportedOSPlatformAttribute`
- `System.Runtime.Versioning.UnsupportedOSPlatformGuardAttribute`
- `System.Threading.Tasks.TaskToAsyncResult`
- `System.ValueTuple`
- `System.ValueTuple<T1>`
- `System.ValueTuple<T1, T2>`
- `System.ValueTuple<T1, T2, T3>`
- `System.ValueTuple<T1, T2, T3, T4>`
- `System.ValueTuple<T1, T2, T3, T4, T5>`
- `System.ValueTuple<T1, T2, T3, T4, T5, T6>`
- `System.ValueTuple<T1, T2, T3, T4, T5, T6, T7>`
- `System.ValueTuple<T1, T2, T3, T4, T5, T6, T7, TRest> where TRest : struct`
- `System.ITupleInternal`

### Methods

- `System.Collections.Concurrent.ConcurrentDictionary<TKey, TValue>.GetOrAdd<TArg>(TKey key, System.Func<TKey, TArg, TValue> valueFactory, TArg factoryArgument)`
- `System.Collections.Generic.CollectionExtensions.GetValueOrDefault<TKey, TValue>(this System.Collections.Generic.IReadOnlyDictionary<TKey, TValue> dictionary, TKey key)`
- `System.Collections.Generic.CollectionExtensions.GetValueOrDefault<TKey, TValue>(this System.Collections.Generic.IReadOnlyDictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue)`
- `System.Collections.Generic.KeyValuePair<TKey, TValue>.Deconstruct(out TKey key, out TValue value)`
- `System.Collections.Generic.Queue<T>.TryDequeue(out T result)`
- `System.Collections.Immutable.ImmutableArray<T>.AsSpan(System.Int32 start, System.Int32 length)`
- `System.Collections.Immutable.ImmutableArray<T>.AsSpan(System.Range range)`
- `System.Diagnostics.Process.WaitForExitAsync([System.Threading.CancellationToken cancellationToken = default])`
- `System.IO.Stream.Read(System.Span<System.Byte> buffer)`
- `System.IO.Stream.ReadAsync(System.Memory<System.Byte> buffer, [System.Threading.CancellationToken cancellationToken = default])`
- `System.IO.Stream.ReadAtLeast(System.Span<System.Byte> buffer, System.Int32 minimumBytes, [System.Boolean throwOnEndOfStream = true])`
- `System.IO.Stream.ReadAtLeastAsync(System.Memory<System.Byte> buffer, System.Int32 minimumBytes, [System.Boolean throwOnEndOfStream = true], [System.Threading.CancellationToken cancellationToken = default])`
- `System.IO.Stream.Write(System.ReadOnlySpan<System.Byte> buffer)`
- `System.IO.Stream.WriteAsync(System.ReadOnlyMemory<System.Byte> buffer, [System.Threading.CancellationToken cancellationToken = default])`
- `System.IO.StreamReader.ReadLineAsync()`
- `System.IO.StreamReader.ReadLineAsync(System.Threading.CancellationToken cancellationToken)`
- `System.IO.TextReader.ReadAsync(System.Memory<System.Char> buffer, [System.Threading.CancellationToken cancellationToken = default])`
- `System.IO.TextReader.ReadToEndAsync(System.Threading.CancellationToken cancellationToken)`
- `System.IO.TextWriter.WriteAsync(System.ReadOnlyMemory<System.Char> buffer, [System.Threading.CancellationToken cancellationToken = default])`
- `System.Linq.Enumerable.AggregateBy<TSource, TKey, TAccumulate>(this System.Collections.Generic.IEnumerable<TSource> source, System.Func<TSource, TKey> keySelector, System.Func<TKey, TAccumulate> seedSelector, System.Func<TAccumulate, TSource, TAccumulate> func, [System.Collections.Generic.IEqualityComparer<TKey>? keyComparer = null]) where TKey : notnull`
- `System.Linq.Enumerable.AggregateBy<TSource, TKey, TAccumulate>(this System.Collections.Generic.IEnumerable<TSource> source, System.Func<TSource, TKey> keySelector, TAccumulate seed, System.Func<TAccumulate, TSource, TAccumulate> func, [System.Collections.Generic.IEqualityComparer<TKey>? keyComparer = null]) where TKey : notnull`
- `System.Linq.Enumerable.CountBy<TSource, TKey>(this System.Collections.Generic.IEnumerable<TSource> source, System.Func<TSource, TKey> keySelector, [System.Collections.Generic.IEqualityComparer<TKey>? keyComparer = null]) where TKey : notnull`
- `System.Linq.Enumerable.DistinctBy<TSource, TKey>(this System.Collections.Generic.IEnumerable<TSource> source, System.Func<TSource, TKey> keySelector)`
- `System.Linq.Enumerable.DistinctBy<TSource, TKey>(this System.Collections.Generic.IEnumerable<TSource> source, System.Func<TSource, TKey> keySelector, System.Collections.Generic.IEqualityComparer<TKey>? comparer)`
- `System.Linq.Enumerable.Index<TSource>(this System.Collections.Generic.IEnumerable<TSource> source)`
- `System.Linq.Enumerable.MaxBy<TSource, TKey>(this System.Collections.Generic.IEnumerable<TSource> source, System.Func<TSource, TKey> keySelector)`
- `System.Linq.Enumerable.MaxBy<TSource, TKey>(this System.Collections.Generic.IEnumerable<TSource> source, System.Func<TSource, TKey> keySelector, System.Collections.Generic.IComparer<TKey>? comparer)`
- `System.Linq.Enumerable.MinBy<TSource, TKey>(this System.Collections.Generic.IEnumerable<TSource> source, System.Func<TSource, TKey> keySelector)`
- `System.Linq.Enumerable.MinBy<TSource, TKey>(this System.Collections.Generic.IEnumerable<TSource> source, System.Func<TSource, TKey> keySelector, System.Collections.Generic.IComparer<TKey>? comparer)`
- `System.Linq.Enumerable.OrderDescending<T>(this System.Collections.Generic.IEnumerable<T> source)`
- `System.Linq.Enumerable.OrderDescending<T>(this System.Collections.Generic.IEnumerable<T> source, System.Collections.Generic.IComparer<T>? comparer)`
- `System.Linq.Enumerable.Order<T>(this System.Collections.Generic.IEnumerable<T> source)`
- `System.Linq.Enumerable.Order<T>(this System.Collections.Generic.IEnumerable<T> source, System.Collections.Generic.IComparer<T>? comparer)`
- `System.Linq.Enumerable.ToHashSet<TSource>(this System.Collections.Generic.IEnumerable<TSource> source)`
- `System.Linq.Enumerable.ToHashSet<TSource>(this System.Collections.Generic.IEnumerable<TSource> source, System.Collections.Generic.IEqualityComparer<TSource>? comparer)`
- `System.Linq.Enumerable.Zip<TFirst, TSecond>(this System.Collections.Generic.IEnumerable<TFirst> first, System.Collections.Generic.IEnumerable<TSecond> second)`
- `System.MemoryExtensions.AsSpan(this System.String? text, System.Int32 start, System.Int32 length)`
- `System.MemoryExtensions.CommonPrefixLength<T>(this System.ReadOnlySpan<T> span, System.ReadOnlySpan<T> other)`
- `System.MemoryExtensions.CommonPrefixLength<T>(this System.ReadOnlySpan<T> span, System.ReadOnlySpan<T> other, System.Collections.Generic.IEqualityComparer<T>? comparer)`
- `System.MemoryExtensions.CommonPrefixLength<T>(this System.Span<T> span, System.ReadOnlySpan<T> other)`
- `System.MemoryExtensions.CommonPrefixLength<T>(this System.Span<T> span, System.ReadOnlySpan<T> other, System.Collections.Generic.IEqualityComparer<T>? comparer)`
- `System.MemoryExtensions.ContainsAnyExcept<T>(this System.ReadOnlySpan<T> span, System.ReadOnlySpan<T> values) where T : System.IEquatable<T>?`
- `System.MemoryExtensions.ContainsAnyExcept<T>(this System.ReadOnlySpan<T> span, T value) where T : System.IEquatable<T>?`
- `System.MemoryExtensions.ContainsAnyExcept<T>(this System.ReadOnlySpan<T> span, T value0, T value1) where T : System.IEquatable<T>?`
- `System.MemoryExtensions.ContainsAnyExcept<T>(this System.ReadOnlySpan<T> span, T value0, T value1, T value2) where T : System.IEquatable<T>?`
- `System.MemoryExtensions.ContainsAnyExcept<T>(this System.Span<T> span, System.ReadOnlySpan<T> values) where T : System.IEquatable<T>?`
- `System.MemoryExtensions.ContainsAnyExcept<T>(this System.Span<T> span, T value) where T : System.IEquatable<T>?`
- `System.MemoryExtensions.ContainsAnyExcept<T>(this System.Span<T> span, T value0, T value1) where T : System.IEquatable<T>?`
- `System.MemoryExtensions.ContainsAnyExcept<T>(this System.Span<T> span, T value0, T value1, T value2) where T : System.IEquatable<T>?`
- `System.MemoryExtensions.ContainsAny<T>(this System.Span<T> span, System.ReadOnlySpan<T> values) where T : System.IEquatable<T>?`
- `System.MemoryExtensions.ContainsAny<T>(this System.Span<T> span, T value0, T value1) where T : System.IEquatable<T>?`
- `System.MemoryExtensions.ContainsAny<T>(this System.Span<T> span, T value0, T value1, T value2) where T : System.IEquatable<T>?`
- `System.MemoryExtensions.Contains<T>(this System.ReadOnlySpan<T> span, T value) where T : System.IEquatable<T>?`
- `System.MemoryExtensions.Contains<T>(this System.Span<T> span, T value) where T : System.IEquatable<T>?`
- `System.MemoryExtensions.IndexOfAnyExcept<T>(this System.ReadOnlySpan<T> span, System.ReadOnlySpan<T> values) where T : System.IEquatable<T>?`
- `System.MemoryExtensions.IndexOfAnyExcept<T>(this System.ReadOnlySpan<T> span, T value) where T : System.IEquatable<T>?`
- `System.MemoryExtensions.IndexOfAnyExcept<T>(this System.ReadOnlySpan<T> span, T value0, T value1) where T : System.IEquatable<T>?`
- `System.MemoryExtensions.IndexOfAnyExcept<T>(this System.ReadOnlySpan<T> span, T value0, T value1, T value2) where T : System.IEquatable<T>?`
- `System.MemoryExtensions.IndexOfAnyExcept<T>(this System.Span<T> span, System.ReadOnlySpan<T> values) where T : System.IEquatable<T>?`
- `System.MemoryExtensions.IndexOfAnyExcept<T>(this System.Span<T> span, T value) where T : System.IEquatable<T>?`
- `System.MemoryExtensions.IndexOfAnyExcept<T>(this System.Span<T> span, T value0, T value1) where T : System.IEquatable<T>?`
- `System.MemoryExtensions.IndexOfAnyExcept<T>(this System.Span<T> span, T value0, T value1, T value2) where T : System.IEquatable<T>?`
- `System.Net.Http.HttpContent.CopyTo(System.IO.Stream stream, System.Net.TransportContext? context, System.Threading.CancellationToken cancellationToken)`
- `System.Net.Http.HttpContent.CopyToAsync(System.IO.Stream stream)`
- `System.Net.Http.HttpContent.CopyToAsync(System.IO.Stream stream, System.Net.TransportContext? context)`
- `System.Net.Http.HttpContent.CopyToAsync(System.IO.Stream stream, System.Net.TransportContext? context, System.Threading.CancellationToken cancellationToken)`
- `System.Net.Http.HttpContent.CopyToAsync(System.IO.Stream stream, System.Threading.CancellationToken cancellationToken)`
- `System.Net.Http.HttpContent.ReadAsStream(System.Threading.CancellationToken cancellationToken)`
- `System.Net.Http.HttpContent.ReadAsStream()`
- `System.Net.Sockets.UdpClient.Send(System.ReadOnlySpan<System.Byte> datagram, System.Net.IPEndPoint? endPoint)`
- `System.Net.Sockets.UdpClient.Send(System.ReadOnlySpan<System.Byte> datagram, System.String? hostname, System.Int32 port)`
- `System.String.Contains(System.Char value)`
- `System.String.Contains(System.Char value, System.StringComparison comparisonType)`
- `System.String.Contains(System.String value, System.StringComparison comparisonType)`
- `System.String.CopyTo(System.Span<System.Char> destination)`
- `System.String.EndsWith(System.Char value)`
- `System.String.GetHashCode(System.StringComparison comparisonType)`
- `System.String.IndexOf(System.Char value, System.StringComparison comparisonType)`
- `System.String.Replace(System.String oldValue, System.String? newValue, System.StringComparison comparisonType)`
- `System.String.ReplaceLineEndings(System.String replacementText)`
- `System.String.ReplaceLineEndings()`
- `System.String.Split(System.Char separator, System.Int32 count, [System.StringSplitOptions options = System.StringSplitOptions.None])`
- `System.String.Split(System.Char separator, [System.StringSplitOptions options = System.StringSplitOptions.None])`
- `System.String.StartsWith(System.Char value)`
- `System.String.TryCopyTo(System.Span<System.Char> destination)`
- `System.Text.Encoding.GetString(System.ReadOnlySpan<System.Byte> bytes)`
- `System.Text.StringBuilder.Append(System.ReadOnlyMemory<System.Char> value)`
- `System.Text.StringBuilder.Append(System.ReadOnlySpan<System.Char> value)`
- `System.Text.StringBuilder.AppendJoin(System.Char separator, params System.Object?[] values)`
- `System.Text.StringBuilder.AppendJoin(System.Char separator, params System.String?[] values)`
- `System.Text.StringBuilder.AppendJoin(System.String? separator, params System.Object?[] values)`
- `System.Text.StringBuilder.AppendJoin(System.String? separator, params System.String?[] values)`
- `System.Text.StringBuilder.AppendJoin<T>(System.Char separator, System.Collections.Generic.IEnumerable<T> values)`
- `System.Text.StringBuilder.AppendJoin<T>(System.String? separator, System.Collections.Generic.IEnumerable<T> values)`
- `System.Text.StringBuilder.Replace(System.ReadOnlySpan<System.Char> oldValue, System.ReadOnlySpan<System.Char> newValue)`
- `System.Text.StringBuilder.Replace(System.ReadOnlySpan<System.Char> oldValue, System.ReadOnlySpan<System.Char> newValue, System.Int32 startIndex, System.Int32 count)`
- `System.Threading.CancellationTokenSource.CancelAsync()`
- `System.Threading.Tasks.Task.WaitAsync(System.Threading.CancellationToken cancellationToken)`
- `System.Threading.Tasks.TaskAsyncEnumerableExtensions.ToBlockingEnumerable<T>(this System.Collections.Generic.IAsyncEnumerable<T> source, [System.Threading.CancellationToken cancellationToken = default])`
- `System.Type.IsAssignableTo(System.Type? targetType)`

<!-- end_polyfills -->

## Contribution

#### How to add a new polyfill

- Create a new file named `<xml documentation id>.cs` in the project `Meziantou.Polyfill.Editor`
- Run `Meziantou.Polyfill.Generator`

Notes:
- All files must be self contained. Use a `file class` if needed.
- If you need to generate a file only when another polyfill is generated, add `// when <xml documentation id>` in the file
