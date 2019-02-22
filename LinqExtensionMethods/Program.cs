using System;
using System.Linq;
using System.Collections.Generic;

namespace LinqExtensionMethods {

    class Program {
        delegate void ExtensionMethod();
        void Aggregate() {
            // 1st param is a seed for the aggregation
            int[] ints = { 91, 62, 23, 74, 35 };
            var max = ints.Aggregate(int.MinValue, (curr, next) => next > curr ? next : curr, i => i);
            Print($"Aggregate: Max value is {max}");
        }
        void All() {
            // checks all in the collection
            int[] ints = { 2, 4, 6, 8, 10, 11 };
            var allEven = ints.All(i => i % 2 == 0);
            Print($"All: All ints are even: {allEven}");
        }
        void Any() {
            // checks if any in collection match condition
            int[] ints = { 2, 4, 6, 8, 10, 11 };
            var anyOdd = ints.Any(i => i % 2 == 1);
            Print($"Any: Any ints are odd: {anyOdd}");
        }
        void Append() {
            // appends an item to the end of the collection
            int[] ints = { 1, 2, 3, 4 };
            ints = ints.Append(5).ToArray();
            Print(string.Join(',', ints));
        }
        void Average() {
            // calculates the average
            int[] ints = { 2, 4, 6, 8, 10, 11 };
            var avg = ints.Average();
            Print($"Average: avg is {avg}");
        }
        void Cast() {
            Int64[] ints = { 2, 4, 6, 8, 10, 11 };
            var strs = ints.Cast<long>(); //.Select(i => i); //.ToArray();
            foreach(var s in strs) {
                Print($"s = {s} is type {s.GetType().Name}");
            }
        }
        void Concat() {
            // concatenates to collections
            int[] ints1 = { 1, 2, 3, 4 };
            int[] ints2 = { 2, 4, 6, 8, 10, 11 };
            var allInts = ints2.Select(i => i).Concat(ints1.Select(i => i)).ToList();
            Print(string.Join(',', allInts));
        }
        void Contains() {
            int[] ints = { 79, 95, 97, 46, 29, 53, 36, 44, 46, 6 };
            var result = ints.Contains(29);
            Print($"ints includes 88: {result}");
        }
        void Count() {
            int[] ints = { 1, 2, 3, 4, 5 };
            var count = ints.Count();
            Print($"ints has {count} items");
        }
        void DefaultIfEmpty() {
            int[] empty =  { };
            int defInt = 0;
            int[] some = { 1, 2, 3, 4, 5 };
            var result = empty.DefaultIfEmpty(defInt);
            Print($"DefaultIfEmpty: {string.Join(',', result)}");
            result = some.DefaultIfEmpty(defInt);
            Print($"DefaultIfEmpty: {string.Join(',', result)}");
        }
        void Distinct() {
            int[] someDups = { 1, 1, 2, 2, 3, 3, 4, 4, 5, 5 };
            var noDups = someDups.Distinct();
            Print($"Distinct: {string.Join(',', noDups)}");
        }
        void ElementAt() {
            int[] some = { 1, 2, 3, 4, 5 };
            var result = some.ElementAt(2); // should be 3
            Print($"ElementAt: Should be 3: {result}");
        }
        void ElementAtOrDefault() {
            int[] some = { 1, 2, 3, 4, 5 };
            var result = some.ElementAtOrDefault(7); // should be defaul
            Print($"ElementAt: Should be default zero: {result}");
            result = some.ElementAtOrDefault(2); // should be 3
            Print($"ElementAt: Should be 3: {result}");
        }
        void Empty() {
            var result = Enumerable.Empty<int>();
            Print($"Empty: creates an empty array, count: {result.Count()}");
        }
        void Except() {
            // members of first not existing in second
            int[] first = { 1, 2, 3, 4, 5 };
            int[] second = { 3, 4, 5, 6, 7 };
            var result = first.Except(second);
            Print($"Except: items in first not in second: {string.Join(',', result)}");
        }
        void First() {
            int[] ints = { 1, 2, 3, 4, 5 };
            var result = ints.First(i => i % 3 == 0);
            Print($"First: should be 3: {result}");
        }
        void FirstOrDefault() {
            int[] ints = { 1, 2, 3, 4, 5 };
            var result = ints.FirstOrDefault(i => i % 11 == 0);
            Print($"FirstOrDefault: should be zero: {result}");
            result = ints.FirstOrDefault(i => i % 5 == 0);
            Print($"FirstOrDefault: should be 5: {result}");
        }
        struct item {
            public string cat;
            public int value;
        };
        void GroupBy() {
            item[] items = {
                new item { cat = "A", value = 1 },
                new item { cat = "B", value = 2 },
                new item { cat = "A", value = 3 },
                new item { cat = "B", value = 4 },
                new item { cat = "A", value = 5 }
            };
            var result = items.GroupBy(i => i.cat, 
                i => i.value, (c, v) => new { Cat = c, Sum = v.Sum() }).ToList();
            result.ForEach(i => Print($"Cat: {i.Cat}, Val: {i.Sum}"));
        }
        void Intersect() {

        }
        void Join() { }
        void Last() { }
        void LastOrDefault() { }
        void LongCount() { }
        void Max() { }
        void Min() { }
        void OfType() { }
        void OrderBy() { }
        void OrderByDescending() { }
        void Prepend() { }
        void Range() { }
        void Repeat() { }
        void Reverse() { }
        void Select() { }
        void SelectMany() { }
        void SequenceEqual() { }
        void Single() { }
        void SingleOrDefault() { }
        void Skip() { }
        void SkipLast() { }
        void SkipWhile() { }
        void Sum() { }
        void Take() { }
        void TakeLast() { }
        void TakeWhile() { }
        void ThenBy() { }
        void ThenByDescending() { }
        void ToArray() { }
        void ToDictionary() { }
        void ToHashSet() { }
        void ToList() { }
        void ToLookup() { }
        void Union() { }
        void Where() { }
        void Zip() { }

        void Run() {
            ExtensionMethod[] methods = {
                Aggregate, All, Any, Append, Average, Cast, Concat, Contains, Count, DefaultIfEmpty,
                Distinct, ElementAt, ElementAtOrDefault, Empty, Except, First, FirstOrDefault,
                GroupBy, Intersect, Join, Last, LastOrDefault, LongCount, Max, Min, OfType, OrderBy,
                OrderByDescending, Prepend, Range, Repeat, Reverse, Select, SelectMany, SequenceEqual,
                Single, SingleOrDefault, Skip, SkipLast, SkipWhile, Sum, Take, TakeLast, TakeWhile,
                ThenBy, ThenByDescending, ToArray, ToDictionary, ToHashSet, ToList, ToLookup, Union,
                Where, Zip
            };
            foreach(var method in methods) {
                method();
            }
        }
        void Print(string message) {
            Console.WriteLine(message);
            System.Diagnostics.Debug.WriteLine(message);
        }
        static void Main(string[] args) {
            (new Program()).Run();
        }
    }
}
