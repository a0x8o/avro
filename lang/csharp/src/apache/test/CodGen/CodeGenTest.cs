/**
 * Licensed to the Apache Software Foundation (ASF) under one
 * or more contributor license agreements.  See the NOTICE file
 * distributed with this work for additional information
 * regarding copyright ownership.  The ASF licenses this file
 * to you under the Apache License, Version 2.0 (the
 * "License"); you may not use this file except in compliance
 * with the License.  You may obtain a copy of the License at
 *
 *     https://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp;
using NUnit.Framework;

namespace Avro.Test.CodeGen
{
    [TestFixture]
    class CodeGenTests
    {
<<<<<<< HEAD

        [Test]
        public void TestGetNullableTypeException()
=======
#if !NETCOREAPP // System.CodeDom compilation not supported in .NET Core: https://github.com/dotnet/corefx/issues/12180
        [TestCase(@"{
""type"" : ""record"",
""name"" : ""ClassKeywords"",
""namespace"" : ""com.base"",
""fields"" :
		[ 	
			{ ""name"" : ""int"", ""type"" : ""int"" },
			{ ""name"" : ""base"", ""type"" : ""long"" },
			{ ""name"" : ""event"", ""type"" : ""boolean"" },
			{ ""name"" : ""foreach"", ""type"" : ""double"" },
			{ ""name"" : ""bool"", ""type"" : ""float"" },
			{ ""name"" : ""internal"", ""type"" : ""bytes"" },
			{ ""name"" : ""while"", ""type"" : ""string"" },
			{ ""name"" : ""return"", ""type"" : ""null"" },
			{ ""name"" : ""enum"", ""type"" : { ""type"" : ""enum"", ""name"" : ""class"", ""symbols"" : [ ""Unknown"", ""A"", ""B"" ], ""default"" : ""Unknown"" } },
			{ ""name"" : ""string"", ""type"" : { ""type"": ""fixed"", ""size"": 16, ""name"": ""static"" } }
		]
}
", new object[] {"com.base.ClassKeywords", typeof(int), typeof(long), typeof(bool), typeof(double), typeof(float), typeof(byte[]), typeof(string),typeof(object),"com.base.class", "com.base.static"}, TestName = "TestCodeGen0")]
        [TestCase(@"{
""type"" : ""record"",
""name"" : ""AvroNamespaceType"",
""namespace"" : ""My.Avro"",
""fields"" :
		[
			{ ""name"" : ""justenum"", ""type"" : { ""type"" : ""enum"", ""name"" : ""justenumEnum"", ""symbols"" : [ ""One"", ""Two"" ] } },
		]
}
", new object[] {"My.Avro.AvroNamespaceType", "My.Avro.justenumEnum"}, TestName = "TestCodeGen3 - Avro namespace conflict")]
        [TestCase(@"{
""type"" : ""record"",
""name"" : ""SchemaObject"",
""namespace"" : ""schematest"",
""fields"" :
	[ 	
		{ ""name"" : ""myobject"", ""type"" :
			[
				""null"",
				{""type"" : ""array"", ""items"" : [ ""null"",
											{ ""type"" : ""enum"", ""name"" : ""MyEnum"", ""symbols"" : [ ""A"", ""B"" ] },
											{ ""type"": ""fixed"", ""size"": 16, ""name"": ""MyFixed"" }
											]
				}
			]
		}
	]
}
", new object[] { "schematest.SchemaObject", typeof(IList<object>) }, TestName = "TestCodeGen1")]
        [TestCase(@"{
	""type"" : ""record"",
	""name"" : ""LogicalTypes"",
	""namespace"" : ""schematest"",
	""fields"" :
		[ 	
			{ ""name"" : ""nullibleguid"", ""type"" : [""null"", {""type"": ""string"", ""logicalType"": ""uuid"" } ]},
			{ ""name"" : ""guid"", ""type"" : {""type"": ""string"", ""logicalType"": ""uuid"" } },
			{ ""name"" : ""nullibletimestampmillis"", ""type"" : [""null"", {""type"": ""long"", ""logicalType"": ""timestamp-millis""}]  },
			{ ""name"" : ""timestampmillis"", ""type"" : {""type"": ""long"", ""logicalType"": ""timestamp-millis""} },
			{ ""name"" : ""nullibiletimestampmicros"", ""type"" : [""null"", {""type"": ""long"", ""logicalType"": ""timestamp-micros""}]  },
			{ ""name"" : ""timestampmicros"", ""type"" : {""type"": ""long"", ""logicalType"": ""timestamp-micros""} },
			{ ""name"" : ""nullibiletimemicros"", ""type"" : [""null"", {""type"": ""long"", ""logicalType"": ""time-micros""}]  },
			{ ""name"" : ""timemicros"", ""type"" : {""type"": ""long"", ""logicalType"": ""time-micros""} },
			{ ""name"" : ""nullibiletimemillis"", ""type"" : [""null"", {""type"": ""int"", ""logicalType"": ""time-millis""}]  },
			{ ""name"" : ""timemillis"", ""type"" : {""type"": ""int"", ""logicalType"": ""time-millis""} },
			{ ""name"" : ""nullibledecimal"", ""type"" : [""null"", {""type"": ""bytes"", ""logicalType"": ""decimal"", ""precision"": 4, ""scale"": 2}]  },
            { ""name"" : ""decimal"", ""type"" : {""type"": ""bytes"", ""logicalType"": ""decimal"", ""precision"": 4, ""scale"": 2} }
		]
}
", new object[] { "schematest.LogicalTypes", typeof(Guid?), typeof(Guid), typeof(DateTime?), typeof(DateTime), typeof(DateTime?), typeof(DateTime), typeof(TimeSpan?), typeof(TimeSpan), typeof(TimeSpan?), typeof(TimeSpan), typeof(AvroDecimal?), typeof(AvroDecimal) }, TestName = "TestCodeGen2 - Logical Types")]
        public static void TestCodeGen(string str, object[] result)
>>>>>>> f9bcab5 (AVRO-3317: JavaScript: Update dependencies)
        {
            Assert.Throws<ArgumentNullException>(() => Avro.CodeGen.GetNullableType(null));
        }

        [Test]
        public void TestReservedKeywords()
        {
            // https://github.com/dotnet/roslyn/blob/main/src/Compilers/CSharp/Portable/Syntax/SyntaxKindFacts.cs

            // Check if all items in CodeGenUtil.Instance.ReservedKeywords are keywords
            foreach (string keyword in CodeGenUtil.Instance.ReservedKeywords)
            {
                Assert.That(SyntaxFacts.GetKeywordKind(keyword) != SyntaxKind.None, Is.True);
            }

            // Check if all Roslyn defined keywords are in CodeGenUtil.Instance.ReservedKeywords
            foreach (SyntaxKind keywordKind in SyntaxFacts.GetReservedKeywordKinds())
            {
                Assert.That(CodeGenUtil.Instance.ReservedKeywords, Does.Contain(SyntaxFacts.GetText(keywordKind)));
            }

            // If this test fails, CodeGenUtil.ReservedKeywords list must be updated.
            // This might happen if newer version of C# language defines new reserved keywords.
        }

        [TestCase("a", "a")]
        [TestCase("a.b", "a.b")]
        [TestCase("a.b.c", "a.b.c")]
        [TestCase("int", "@int")]
        [TestCase("a.long.b", "a.@long.b")]
        [TestCase("int.b.c", "@int.b.c")]
        [TestCase("a.b.int", "a.b.@int")]
        [TestCase("int.long.while", "@int.@long.@while")] // Reserved keywords
        [TestCase("a.value.partial", "a.value.partial")] // Contextual keywords
        [TestCase("a.value.b.int.c.while.longpartial", "a.value.b.@int.c.@while.longpartial")] // Reserved and contextual keywords
        public void TestMangleUnMangle(string input, string mangled)
        {
            // Mangle
            Assert.That(CodeGenUtil.Instance.Mangle(input), Is.EqualTo(mangled));
            // Unmangle
            Assert.That(CodeGenUtil.Instance.UnMangle(mangled), Is.EqualTo(input));
        }

        [TestFixture]
        public class CodeGenTestClass : Avro.CodeGen
        {
            [Test]
            public void TestGenerateNamesException()
            {
                Protocol protocol = null;
                Assert.Throws<ArgumentNullException>(() => this.GenerateNames(protocol));
            }
        }
    }
}
