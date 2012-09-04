using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;


namespace TrainingTasks5
{

    using CustomExtenstions;
    [TestFixture]
    public class NewLinqOperatorTests
    {
        // Implement WhereIf linq operator which takes a boolean condition and a predicate and only evaluates the predicate if the condition is true.
        // eg. list.WhereIf(true, x=>x.IsActive);



        // Implement Alternate which when given an additional list will return the 1 element from the first list then 1 from the second and so on.
        // eg. list.Alternate(list2);

        [Test]
        public void whereif_Beverages()
        {
            var myCase = true;

            var result = Data.GetProducts().WhereIf(myCase, p => p.Category == "Beverages");


            Assert.AreEqual(12, result.Count());
        }

        [Test]
        public void whereif_Beverages_false()
        {
            var myCase = false;

            var result = Data.GetProducts().WhereIf(myCase, p => p.Category == "Beverages");


            Assert.AreEqual(77, result.Count());
        }

        [Test]
        public void alternate()
        {
            List<Product> list = new List<Product>{
                new Product {ProductID = 300, ProductName = "Test300", Category = "Beverages", UnitPrice = 18.0000M, UnitsInStock = 39 },
                 new Product {ProductID = 301, ProductName = "Test301", Category = "Beverages", UnitPrice = 18.0000M, UnitsInStock = 39 }
            };

            var products = Data.GetProducts().Alternate(list);
            var productIds = products.Select(x => new { x.ProductID ,x.ProductName }).ToList();

            Assert.AreEqual(300, productIds[0].ProductID);
            Assert.AreEqual("Test300", productIds[0].ProductName);
            Assert.AreEqual(1, productIds[1].ProductID);
            Assert.AreEqual("Chai", productIds[1].ProductName);
            Assert.AreEqual(301, productIds[2].ProductID);
            Assert.AreEqual("Test301", productIds[2].ProductName);
        }
    }
}

namespace CustomExtenstions
{
    using TrainingTasks5;
    public static class DataExtensions
    {
        public static IEnumerable<T> WhereIf<T>(this IEnumerable<T> source, bool condition, Func<T, bool> predicate)
        {
            if (condition)
                return source.Where(predicate);
            else
                return source;
        }


        public static IEnumerable<T> Alternate<T>(this IEnumerable<T> source, IEnumerable<T> list)
        {

            using (IEnumerator<T> source1 = list.GetEnumerator())
            using (IEnumerator<T> source2 = source.GetEnumerator())
                while (source1.MoveNext() && source2.MoveNext())
                {
                    yield return source1.Current;
                    yield return source2.Current;                   
                }
        }

    }
}


