using DragonJson;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    public class Program
    {

        static bool isTestArray = false;

        static void ClassArray<T>(int loopCount, string fileName, int length)
        {
            DragonJson.JsonReader jsonReader = new DragonJson.JsonReader();
            string str = File.ReadAllText(fileName);
            Stopwatch oTime = new Stopwatch();

            Newtonsoft.Json.JsonSerializerSettings settings = new Newtonsoft.Json.JsonSerializerSettings
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                TypeNameHandling = TypeNameHandling.All,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize
            };

            //int runCount = 1000;
            Console.WriteLine("预热");
            //预热
            for (int __1 = 0; __1 < loopCount; __1++)
            {

                //T _DragonJson = jsonReader.ReadJsonTextCreate<T>(str);
                //T _Newtonsoft = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(str); // ,settings
                //T _Utf8Json = Utf8Json.JsonSerializer.Deserialize<T>(str, Utf8Json.Resolvers.StandardResolver.AllowPrivate);
                //T _LitJson = LitJson.JsonMapper.ToObject<T>(str);
                //T _CatJson = CatJson.JsonParser.ParseJson<T>(str);
            }
            //预热结束
            Console.WriteLine("预热结束");
            for (int i = 0; i < length; i++)
            {

                {
                    oTime.Reset(); oTime.Start();
                    for (int __1 = 0; __1 < loopCount; __1++)
                    {
                        T _DragonJson = jsonReader.ReadJsonTextCreate<T>(str);
                    }
                    oTime.Stop();
                    Console.WriteLine("DragonJson：{0} 毫秒", (oTime.Elapsed).TotalMilliseconds);
                }
                double dog = (oTime.Elapsed).TotalMilliseconds;

                {
                    //Console.WriteLine(str);

                    oTime.Reset(); oTime.Start();
                    for (int __1 = 0; __1 < loopCount; __1++)
                    {
                        T _Newtonsoft = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(str); // ,settings
                    }
                    oTime.Stop();
                    Console.WriteLine("Newtonsoft.Json：{0} 毫秒", (oTime.Elapsed).TotalMilliseconds);
                }
                double newton = (oTime.Elapsed).TotalMilliseconds;


                {
                    //str = Utf8Json.JsonSerializer.ToJsonString<TestClass2>(inputData, Utf8Json.Resolvers.StandardResolver.AllowPrivate);
                    //str = Utf8Json.JsonSerializer.PrettyPrint(str);
                    //Console.WriteLine(str);
                    oTime.Reset(); oTime.Start();
                    for (int __1 = 0; __1 < loopCount; __1++)
                    {
                        T _Utf8Json = Utf8Json.JsonSerializer.Deserialize<T>(str, Utf8Json.Resolvers.StandardResolver.AllowPrivate);
                    }
                    oTime.Stop();
                    Console.WriteLine("Utf8Json.Json：{0} 毫秒", (oTime.Elapsed).TotalMilliseconds);
                }
                double utf8 = (oTime.Elapsed).TotalMilliseconds;

                {
                    oTime.Reset(); oTime.Start();
                    for (int __1 = 0; __1 < loopCount; __1++)
                    {
                        T _LitJson = LitJson.JsonMapper.ToObject<T>(str);
                    }
                    oTime.Stop();
                    Console.WriteLine("LitJson：{0} 毫秒", (oTime.Elapsed).TotalMilliseconds);
                }
                double lit = (oTime.Elapsed).TotalMilliseconds;


                {
                    oTime.Reset(); oTime.Start();
                    for (int __1 = 0; __1 < loopCount; __1++)
                    {
                        T _CatJson = CatJson.JsonParser.ParseJson<T>(str);
                    }
                    oTime.Stop();
                    Console.WriteLine("CatJson：{0} 毫秒", (oTime.Elapsed).TotalMilliseconds);
                }
                double cat = (oTime.Elapsed).TotalMilliseconds;


                Console.WriteLine("第{0}轮比较结果", i + 1);
                Console.WriteLine("是 Newtonsoft 的 {0} 倍", newton / dog);
                Console.WriteLine("是 Utf8Json 的 {0} 倍", utf8 / dog);
                Console.WriteLine("是 LitJson 的 {0} 倍", lit / dog);
                Console.WriteLine("是 CatJson 的 {0} 倍", cat / dog);
                Console.WriteLine();

            }

        }


        static unsafe void Main(string[] args)
        {
            ClassArray<TestClassArray>(10000, "TestJson002.json", 3);
            //ClassArray<TestClass2>(10000, "TestJson001.json", 3);
            Console.ReadKey();
        }


        static void SaveData()
        {
            TestClassArray2 inputData = new TestClassArray2()
            {
                varDouble = 1.2,
                varFloat = 1.23f,
                varInt = 566,
                varLong = 18,
                varBool = true,
                varChar = 'c',
                varString = "BNUY*Fhi89#$^&",

                VarDouble2 = 4.9E+18f,
                VarFloat2 = 1.2E-18f,
                VarInt2 = -5435,
                VarLong2 = -18,
                VarBool2 = true,
                VarChar2 = 'c',
                VarString2 = "BNUY*Fhi89#$^&",

                testStruct = new TestStruct3()
                {
                    varDouble = 1.2,
                    varFloat = 1.23f,
                    varInt = 566,
                    varLong = 18,
                    varBool = true,
                    varChar = 'c',
                    varString = "BNUY*Fhi89#$^&",
                    VarDouble2 = 4.9E+18f,
                    VarFloat2 = 1.2E-18f,
                    VarInt2 = -5435,
                    VarLong2 = -18,
                    VarBool2 = true,
                    VarChar2 = 'c',
                    VarString2 = "BNUY*Fhi89#$^&",
                },
                testClass = new TestClass3()
                {
                    varDouble = -1.2,
                    varFloat = 1.23f,
                    varInt = 566,
                    varLong = 18,
                    varBool = true,
                    varChar = 'c',
                    varString = "BNUY*Fhi89#$^&",
                    VarDouble2 = 4.9E+18f,
                    VarFloat2 = 1.2E-18f,
                    VarInt2 = -5435,
                    VarLong2 = -18,
                    VarBool2 = true,
                    VarChar2 = 'c',
                    VarString2 = "BNUY*Fhi89#$^&",
                },
                VarStruct = new TestStruct3()
                {
                    varDouble = 1.2,
                    varFloat = 1.23f,
                    varInt = 566,
                    varLong = 18,
                    varBool = true,
                    varChar = 'c',
                    varString = "BNUY*Fhi89#$^&",
                    VarDouble2 = 4.9E+18f,
                    VarFloat2 = 1.2E-18f,
                    VarInt2 = -5435,
                    VarLong2 = -18,
                    VarBool2 = true,
                    VarChar2 = 'c',
                    VarString2 = "BNUY*Fhi89#$^&",
                },
                VarClass = new TestClass3()
                {
                    varDouble = -1.2,
                    varFloat = 1.23f,
                    varInt = 566,
                    varLong = 18,
                    varBool = true,
                    varChar = 'c',
                    varString = "BNUY*Fhi89#$^&",
                    VarDouble2 = 4.9E+18f,
                    VarFloat2 = 1.2E-18f,
                    VarInt2 = -5435,
                    VarLong2 = -18,
                    VarBool2 = true,
                    VarChar2 = 'c',
                    VarString2 = "BNUY*Fhi89#$^&",
                }
            };
            TestJsonClassA inputDataA = new TestJsonClassA()
            {
                b = true,
                Num = 33.56,
                kk = -15,
                str = "4ERWRds",
                BB = new B
                {
                    str = "Wvs",
                    b = true,
                    num = -9999.232
                },
                gcc = new C
                {
                    k = 12,
                    bbb = {
                        str = "cc",
                        b = true,
                        num = -8.56
                    }
                },
                p3 = {
                    x = 2,
                    y = 1,
                    z = 33
                },
                testOB = {
                    numI = 13,
                    num = 3.6,
                    p3_0 = new P_box_3 {
                        x = 1.2f,
                        y = -1.8f,
                        z = 33
                    },
                    p3_2 = {
                        x = -12,
                        y = 18,
                        z = 3.3f
                    }
                },
                gD = new E
                {
                    k = -3.14E-12,
                    str = "3特瑞aV",
                    b = true
                },
                gDs = new E[] {
                    new E(){
                        k = -6466,
                        str = "FF",
                        b = true
                    },
                    new E(){
                        k = -3.14E-12,
                        str = "RRRR",
                        b = true
                    },
                    new E(){
                        k = 55.999,
                        str = "3特瑞aV",
                        b = true
                    }
                },
                arrayArray3 = new int[] { 1, 2, 3, 4, 5 },
                arrayArray4 = new int[][] {
                    new int[] { 1, 2, 3, 4, 5 },
                    new int[] { 11, 12, 13, 14, 15 },
                    new int[] { 21, 22, 23, 24, 25 }
                },
                arrayArray1 = new int[,,] {
                    {
                        { 1, 2, 3, 4, 5 },
                        { 11, 12, 13, 14, 15 },
                        { 21, 22, 23, 24, 25 }
                    },
                    {
                        { 101, 102, 103, 104, 105 },
                        { 1011, 1012, 1013, 1014, 1015 },
                        { 1021, 1022, 1023, 1024, 1025 }
                    }
                },
                arrayArray2 = new int[,][] {
                    {
                        new int[] { 1, 2, 3, 4, 5 },
                        new int[] { 11, 12, 13, 14, 15 },
                        new int[] { 21, 22, 23, 24, 25 }
                    },
                    {
                        new int[] { 101, 102, 103, 104, 105 },
                        new int[] { 1011, 1012, 1013, 1014, 1015 },
                        new int[] { 1021, 1022, 1023, 1024, 1025 }
                    }
                },
                arrayArray5 = new int[,,] {
                {
                    { 1, 2, 3, 4, 5 },
                    { 11, 12, 13, 14, 15 },
                    { 21, 22, 23, 24, 25 }
                    },
                {
                    { 1001, 1002, 1003, 1004, 1005 },
                    { 1011, 1012, 1013, 1014, 1015 },
                    { 1021, 1022, 1023, 1024, 1025 }
                    }
                },

                ddd = (System.Double)(-3.14E-12),
                objects = new object[] {
                    (System.Int32)(12),
                    (System.Double)(-3.14E-12),
                    new List<int>{1, 2, 4 }
                },
                testEnums = new TestEnum[] { TestEnum.Test002, TestEnum.Test004, TestEnum.Test003 },
                testEnum = TestEnum.Test008 | TestEnum.Test002 | TestEnum.Test003,
                testEnum2 = TestEnum.Test001 | TestEnum.Test002 | TestEnum.Test003,

                listB = new List<B> {
                    new B {
                        str = "00001",
                        b = true,
                        num = -8.56
                    },
                    new B {
                        str = "aaaa2",
                        b = false,
                        num = 10000888.999
                    },
                },

                arrayLinkedList = new LinkedList<long>(new List<long> { 1L, 2L, 3L, 4L, 7L }),// { 1L, 2l, 3l, 4l, 7l }

                arrayStack = new Stack<int>(new List<int> { 3, 4, 5 }),

                arraydouble = new HashSet<double>() {
                    3.333,
                    -4.8888,
                    -5.34E+108
                },
                arraystring = new Queue<string>(
                   new List<string> {
                       "true",
                       "null",
                       "ed false"
                   }
                ),
                listE = new List<E>() {
                   new E(){
                    k = -3E-12,
                    str = "ff出错fvv",
                    b = true
                   },
                   new E(){
                    k = 124,
                    str = "3特瑞aV",
                    b = false
                   },
                   new E(){
                    k = -999.45,
                    str = "_@W#W$%^&",
                    b = true
                   }
                },

                arraybool = new List<bool>() {
                    false,
                    true,
                    false
                },

                arrayint2 = new List<System.Int32> { 14, 24, 34, 44, 54 },

                fd = new B[] {
                    new B {
                        b = true,
                        num = -3.14E-12,
                        str = "ddd"
                    },
                    new B {
                        b = false,
                        num = 34.5
                    },
                    new B {
                        num = 999999
                    }
                },
                dcc = new TclassDCC("3213.#%^&*()", new List<int> { 14, 24, 34, 44, 54 }, -3.14E-12),
                dcc3 = new TclassDCC3("3213.#%^&*()", new List<int> { 14, 24, 34, 44, 54 }, -3.14E-12),
                dcc2 = new TclassDCC("3213.#%^&*()", new List<int> { 14, 24, 34, 44, 54 }, -3.14E-12),

                Iclass0Z = new TclassC
                {
                    b = 122,
                    value = 1.444,
                    bbb = new B
                    {
                        b = true,
                        num = -3.14E-12,
                        str = "hello world"
                    }
                },
                v3 = new Vector3(3, 2, 1),
                testDelegate2 = TClassA.Fool,

                arrayRekn = new B[,,]
                {
                    {
                        {
                            new B {
                                num = 1
                            },
                            new B {
                                num = 2,
                                str = "ddd"
                            }
                        },
                        {
                            new B {
                                num = 3
                            },
                            new B {
                                num = 4
                            }
                        }
                    },
                    {
                        {
                            new B {
                                num = 5,
                                str = "5"
                            },
                            new B {
                                num = 6,
                                str = "6"
                            }
                        },
                        {
                            new B {
                                num = 7,
                                str = "7"
                            },
                            new B {
                                num = 8,
                                str = "8"
                            }
                        }
                    },
                    {
                        {
                            new B {
                                num = 9,
                                str = "9"
                            },
                            new B {
                                num = 10,
                                str = "10"
                            }
                        },
                        {
                            new B {
                                num = 11,
                                str = "11"
                            },
                            new B {
                                num = 12,
                                str = "12"
                            }
                        }
                    }
                },
                tClass001 = new TClass001
                {
                    objects = new object[] {
                        (System.Int32)12,
                        -(System.Double)3.14E-12,
                        (System.String)"3213.#%^&*()",
                    },
                    tClass002s = new TClass002[] {
                        new TClass002 {
                            size = 1,
                            testString = "A@0"
                        },
                        new TClass002 {
                            size = 2,
                            testString = "A@1",
                            tClass003 = new TClass003 {
                                testString = "testClassDD4"
                            },
                            tClass003s = new TClass003[] {
                                new TClass003 {
                                    testString = "0000"
                                },
                                new TClass003 {
                                    testString = "0001"
                                },
                                new TClass003 {
                                    testString = "testClassDD3"
                                }
                            }
                        },
                        new TClass002 {
                            size = 3,
                            testString = "asdede"
                        }
                    },

                    tClass002 = new TClass002
                    {
                        size = 12,
                        tClass003 = new TClass003
                        {
                            testString = "testClassDD"
                        },
                        tClass003s = new TClass003[] {
                            new TClass003 {
                                testString = "0000"
                            },
                            new TClass003 {
                                testString = "0001"
                            },
                            new TClass003 {
                                testString = "testClassDD2"
                            },
                            new TClass003 {
                                testString = "0003"
                            }
                        },

                        testString = "A@2"
                    },
                    TestDuble = -3.14E-12
                },

                dictionary3 = new Dictionary<Vector3, B>()
                {
                    {
                       new Vector3( 3, 2, 1 ),
                       new B {
                            num = 11111,
                            str= "rradads"
                        }
                    },

                    {
                       new Vector3( 1, 4, -9.8f  ),
                       new B {
                            num = 888,
                            str= "热热我"
                        }
                    },

                    {
                       new Vector3( -3.2E-13f, 3.0E+13f, 0.99f ),
                       new B {
                            num = 999999,
                            str= "特别强势人物了"
                        }
                    }
                },

                tstructA = new TstructA
                {
                    value = 3.6,
                    b = new TstructB
                    {
                        kk = "FC",
                        c = new TstructC
                        {
                            Id = 21443,
                        }
                    }
                }
            };
            //isTestArray = false;
            if (isTestArray)
            {
                inputData.ints = new int[] { 1, 2, 3, 4, 5 };
                inputData.Intss = new int[,,] {
                    {
                        { 1, 2, 3, 4, 5, 6 }, { 11, 12, 13, 14, 15, 16 }, { 101, 102, 103, 104, 105, 106 }
                    },
                    {
                        { 91, 92, 93, 94, 95, 96 }, { 911, 912, 913, 914, 915, 916 }, { 9101, 9102, 9103, 9104, 9105, 9106 }
                    },
                    {
                        { 61, 62, 63, 64, 65, 66 }, { 611, 612, 613, 14, 15, 16 }, { 6101, 6102, 6103, 6104, 6105, 6106 }
                    }
                };
                inputData.doubles = new double[,,] {
                    {
                        { 1.2f, 2.455f, 3.0E-13f, 4.888e+15f, -9.456E-13f, -3.888E+15f, -3.0e+14f, 3.0e-14f, -3.0e-14f}, { 1.2f, 2.455f, 3.0E-13f, 4.888e+15f, -9.456E-13f, -3.888E+15f, -3.0e+14f, 3.0e-14f, -3.0e-14f},
                    },
                    {
                        { 1.2f, 2.455f, 3.0E-13f, 4.888e+15f, -9.456E-13f, -3.888E+15f, -3.0e+14f, 3.0e-14f, -3.0e-14f}, { 1.2f, 2.455f, 3.0E-13f, 4.888e+15f, -9.456E-13f, -3.888E+15f, -3.0e+14f, 3.0e-14f, -3.0e-14f},
                    },
                    {
                        { 1.2f, 2.455f, 3.0E-13f, 4.888e+15f, -9.456E-13f, -3.888E+15f, -3.0e+14f, 3.0e-14f, -3.0e-14f}, { 1.2f, 2.455f, 3.0E-13f, 4.888e+15f, -9.456E-13f, -3.888E+15f, -3.0e+14f, 3.0e-14f, -3.0e-14f},
                    }
                };
                inputData.Stringss = new string[,,] {
                    {
                      { "444", "d23re", "*&*(HJ", "大家好！\\u6211\\u662f\\u4f60\\u7238\\u7238！！" },{ "ddd423fdsd", "21DASDADSA", "*&4113##$$*(HJ", "大家好！\\u6211\\u662f\\u4f60\\u7238\\u7238！！" }
                    },
                    {
                      { "#DAD", "此次你们", "*&*(HJ", "大家好！\\u6211\\u662f\\u4f60\\u7238\\u7238！！" },{ "%$^&*(HBGKL", "d23re", "*&*(dd", "大家好！\\u6211\\u662f\\u4f60\\u7238\\u7238！！" }
                    },
                    {
                      { "asdas", "fs344", "*&*(*(GBVU)", "大家好！\\u6211\\u662f\\u4f60\\u7238\\u7238！！" },{ "asdas", "d23re", "*&*(dadsaHJ", "大家好！\\u6211\\u662f\\u4f60\\u7238\\u7238！！" }
                    }
                };
                inputData.strings = new string[] { "#DD的撒旦", "顶顶顶顶顶顶顶顶顶顶", "@#￥%……&DFVG", "", "s" };
                inputData.TestStructs = new TestClass[] {
                    new TestClass()
                    {
                        varBool = false,
                        varChar = 'f',
                        varFloat = 33.444f
                    },
                    new TestClass()
                    {
                        varBool = false,
                        varChar = 'v',
                        varFloat = -3.99999E+12f
                    },
                    new TestClass()
                    {
                        varBool = true,
                        varChar = ' ',
                        varFloat = -888.9999f
                    },
                    new TestClass()
                    {
                        varBool = false,
                        varChar = '@',
                        varFloat = +3.99999E+12f
                    }
                };
                inputData.testClassss = new TestClass[,] {
                   {  new TestClass()
                    {
                        varBool = false,
                        varChar = 'f',
                        varFloat = 33.444f
                    },
                    new TestClass()
                    {
                        varBool = false,
                        varChar = 'v',
                        varFloat = -3.99999E+12f
                    },
                    new TestClass()
                    {
                        varBool = true,
                        varChar = ' ',
                        varFloat = -888.9999f
                    },
                    new TestClass()
                    {
                        varBool = false,
                        varChar = '@',
                        varFloat = +3.99E+12f
                    }},{  new TestClass()
                    {
                        varBool = false,
                        varChar = 'f',
                        varFloat = 33.444f
                    },
                    new TestClass()
                    {
                        varBool = false,
                        varChar = 'v',
                        varFloat = -3.99999E+12f
                    },
                    new TestClass()
                    {
                        varBool = true,
                        varChar = ' ',
                        varFloat = -888.9999f
                    },
                    new TestClass()
                    {
                        varBool = false,
                        varChar = '@',
                        varFloat = +3.99999E+12f
                    }},{  new TestClass()
                    {
                        varBool = false,
                        varChar = 'f',
                        varFloat = 33.444f
                    },
                    new TestClass()
                    {
                        varBool = false,
                        varChar = 'v',
                        varFloat = -3.99999E+12f
                    },
                    new TestClass()
                    {
                        varBool = true,
                        varChar = ' ',
                        varFloat = -888.9999f
                    },
                    new TestClass()
                    {
                        varBool = false,
                        varChar = '@',
                        varFloat = +3.99999E+12f
                    }}
                };
                inputData.testStructs = new TestStuct[] {
                    new TestStuct()
                    {
                        varBool = false,
                        varChar = 'f',
                        varFloat = 33.444f
                    },
                    new TestStuct()
                    {
                        varBool = false,
                        varChar = 'v',
                        varFloat = -3.99999E+12f
                    },
                    new TestStuct()
                    {
                        varBool = true,
                        varChar = ' ',
                        varFloat = -888.9999f
                    },};
            }

            DragonJson.JsonWriter jsonWriter = new DragonJson.JsonWriter(new WriterReflection());
            var str = Newtonsoft.Json.JsonConvert.SerializeObject(inputData, Formatting.Indented);
            str = jsonWriter.Writer(inputData);
            File.WriteAllText("TestJson003.json", str, Encoding.ASCII);
        }


        struct TestStruct3
        {
            public bool varBool;
            public char varChar;
            public double varDouble;
            public float varFloat;
            public int varInt;
            public long varLong;
            public string varString;

            private float varFloat2;
            private double varDouble2;
            private int varIn2t;
            private long varLong2;

            private string varString2;
            private bool varBool2;
            private char varChar2;

            public float VarFloat2 { get => varFloat2; set => varFloat2 = value; }
            public double VarDouble2 { get => varDouble2; set => varDouble2 = value; }
            public int VarInt2 { get => varIn2t; set => varIn2t = value; }
            public long VarLong2 { get => varLong2; set => varLong2 = value; }
            public string VarString2 { get => varString2; set => varString2 = value; }
            public bool VarBool2 { get => varBool2; set => varBool2 = value; }
            public char VarChar2 { get => varChar2; set => varChar2 = value; }
        }

        class TestClass3
        {
            public bool varBool;
            public char varChar;
            public double varDouble;
            public float varFloat;
            public int varInt;
            public long varLong;
            public string varString;

            private float varFloat2;
            private double varDouble2;
            private int varIn2t;
            private long varLong2;

            private string varString2;
            private bool varBool2;
            private char varChar2;

            public float VarFloat2 { get => varFloat2; set => varFloat2 = value; }
            public double VarDouble2 { get => varDouble2; set => varDouble2 = value; }
            public int VarInt2 { get => varIn2t; set => varIn2t = value; }
            public long VarLong2 { get => varLong2; set => varLong2 = value; }
            public string VarString2 { get => varString2; set => varString2 = value; }
            public bool VarBool2 { get => varBool2; set => varBool2 = value; }
            public char VarChar2 { get => varChar2; set => varChar2 = value; }
        }


        class TestClass
        {
            public bool varBool;
            public char varChar;
            public float varFloat;
        }
        struct TestStuct
        {
            public bool varBool;
            public char varChar;
            public float varFloat;
        }

        class TestClass2
        {
            public bool varBool;
            public char varChar;
            public double varDouble;
            public float varFloat;
            public int varInt;
            public long varLong;
            public string varString;
            public TestStruct3 testStruct;
            public TestClass3 testClass;

            private float varFloat2;
            private double varDouble2;
            private int varIn2t;
            private long varLong2;

            private string varString2;
            private bool varBool2;
            private char varChar2;
            private TestStruct3 testStruct2;
            private TestClass3 testClass2;

            public float VarFloat2 { get => varFloat2; set => varFloat2 = value; }
            public double VarDouble2 { get => varDouble2; set => varDouble2 = value; }
            public int VarInt2 { get => varIn2t; set => varIn2t = value; }
            public long VarLong2 { get => varLong2; set => varLong2 = value; }
            public string VarString2 { get => varString2; set => varString2 = value; }
            public bool VarBool2 { get => varBool2; set => varBool2 = value; }
            public char VarChar2 { get => varChar2; set => varChar2 = value; }
            public TestStruct3 VarStruct { get => testStruct2; set => testStruct2 = value; }
            public TestClass3 VarClass { get => testClass2; set => testClass2 = value; }

        }

        class TestClassArray
        {
            public bool varBool;
            public char varChar;
            public double varDouble;
            public float varFloat;
            public int varInt;
            public long varLong;
            public string varString;
            public TestStruct3 testStruct;
            public TestClass3 testClass;

            public int[] ints;
            public string[] strings;
            public TestStuct[] testStructs;

            public int[] Ints { get; set; }
            public string[] Strings { get; set; }
            public TestClass[] TestStructs { get; set; }

            private float varFloat2;
            private double varDouble2;
            private int varIn2t;
            private long varLong2;

            private string varString2;
            private bool varBool2;
            private char varChar2;
            private TestStruct3 testStruct2;
            private TestClass3 testClass2;

            public float VarFloat2 { get => varFloat2; set => varFloat2 = value; }
            public double VarDouble2 { get => varDouble2; set => varDouble2 = value; }
            public int VarInt2 { get => varIn2t; set => varIn2t = value; }
            public long VarLong2 { get => varLong2; set => varLong2 = value; }
            public string VarString2 { get => varString2; set => varString2 = value; }
            public bool VarBool2 { get => varBool2; set => varBool2 = value; }
            public char VarChar2 { get => varChar2; set => varChar2 = value; }
            public TestStruct3 VarStruct { get => testStruct2; set => testStruct2 = value; }
            public TestClass3 VarClass { get => testClass2; set => testClass2 = value; }

        }

        class TestClassArray2
        {
            public bool varBool;
            public char varChar;
            public double varDouble;
            public float varFloat;
            public int varInt;
            public long varLong;
            public string varString;
            public TestStruct3 testStruct;
            public TestClass3 testClass;

            public int[] ints;
            public string[] strings;
            public TestStuct[] testStructs;

            public int[] Ints { get; set; }
            public string[] Strings { get; set; }
            public TestClass[] TestStructs { get; set; }

            public double[,,] doubles;

            public int[,,] Intss { get; set; }
            public string[,,] Stringss { get; set; }
            public TestClass[,] testClassss;


            private float varFloat2;
            private double varDouble2;
            private int varIn2t;
            private long varLong2;

            private string varString2;
            private bool varBool2;
            private char varChar2;
            private TestStruct3 testStruct2;
            private TestClass3 testClass2;

            public float VarFloat2 { get => varFloat2; set => varFloat2 = value; }
            public double VarDouble2 { get => varDouble2; set => varDouble2 = value; }
            public int VarInt2 { get => varIn2t; set => varIn2t = value; }
            public long VarLong2 { get => varLong2; set => varLong2 = value; }
            public string VarString2 { get => varString2; set => varString2 = value; }
            public bool VarBool2 { get => varBool2; set => varBool2 = value; }
            public char VarChar2 { get => varChar2; set => varChar2 = value; }
            public TestStruct3 VarStruct { get => testStruct2; set => testStruct2 = value; }
            public TestClass3 VarClass { get => testClass2; set => testClass2 = value; }

        }

        public class TestJsonClassA
        {
            public Action<int, string> testDelegate;
            public Action<int, string> testDelegate2;
            public Action<int, string> testDelegate3;
            public void Fool(int a, string b)
            {
            }
            public void Foo2(int a, string b)
            {

            }
            ///*
            private double num;
            public double Num
            {
                get { return num; }
                set { num = value; }
            }

            private B bb;
            public B BB
            {
                get { return bb; }
                set { bb = value; }
            }

            public LinkedList<long> arrayLinkedList;
            public int[,,] arrayArray1;
            public int[,][] arrayArray2;
            public int[] arrayArray3;
            public int[][] arrayArray4;
            public int[,,] arrayArray5;

            public List<B> listB;
            public List<C> listC;
            public List<E> listE;

            public bool b;
            public int kk;
            public string str;
            public C gcc;
            public E gD;
            public E[] gDs;
            public Vector3 v3;
            public TestOB testOB;

            public TclassDCC dcc;
            public TclassDCC3 dcc3;
            public object dcc2;

            public object ddd;
            public object[] objects;

            public TClassPath classPath;
            public TClass001 tClass001;
            public TClass003 testClassDD;
            public TClass003 testClassDD2;
            public TClass003 testClassDD3;
            public TClass003 testClassDD4;



            public TestEnum testEnum;
            public TestEnum testEnum2 { get; set; }
            public TestEnum[] testEnums;

            public IList<int> arrayint2;
            public TclassA Iclass0Z;
            public P_box_3 p3;
            public B[,,] arrayRekn;
            public Stack<int> arrayStack;
            public B[] fd;
            public HashSet<double> arraydouble;
            public Queue<string> arraystring;

            public List<bool> arraybool;

            public Dictionary<int, string> dictionary1;
            public Dictionary<int, B> dictionary2;
            public Dictionary<Vector3, B> dictionary3;
            //*/
            public TstructA tstructA;
        }

        public struct TestOB2
        {
            public P_box_3 p3_0;
            public P_box_3 p3_2;
            public int numI;
            public double num;
        }
        public struct TestOB
        {
            private P_box_3 _p3_0;
            public P_box_3 p3_2;
            public int numI;
            public double num;

            public P_box_3 p3_0 { get => _p3_0; set => _p3_0 = value; }
        }
        public struct P_box_3
        {
            public float x;
            public float y;
            public float z;
        }

        public struct P_3
        {
            public float x;
            public float y;
            public float z;
        }

        public struct C
        {
            public double k;
            public B bbb;
        }

        public struct B
        {
            public bool b;
            public double num;
            public string str;
        }

        public class TClassA
        {
            public static void Fool(int a, string b)
            {

            }
            public static void Foo2(int a, string b)
            {

            }

        }

        public struct Vector3
        {
            public Vector3(float x, float y, float z)
            {
                this.x = x;
                this.y = y;
                this.z = z;
            }
            public float x;
            public float y;
            public float z;
            public override bool Equals(object obj)
            {
                if (obj is Vector3)
                {
                    Vector3 v = (Vector3)obj;
                    return v.x == x && v.y == y && v.z == z;
                }
                return false;
            }
            public override int GetHashCode()
            {
                return (x + y + z).GetHashCode();
            }
        }

        [StructLayout(LayoutKind.Explicit)]
        struct D
        {
            [FieldOffset(0)]
            public bool b;

            [FieldOffset(1)]
            public double k;

            [FieldOffset(16)]
            public string str;

            [FieldOffset(40)]
            public E e;
        }
        public class E
        {
            public bool b;
            public double k;
            public string str;
        }
        public class TclassA
        {
            public int b;
            public void Fool(int a, string b)
            {
            }
            public void Foo2(int a, string b)
            {
            }
        }
        public class TclassC : TclassA
        {
            public double value;
            B _bbb;
            public B bbb { get => _bbb; set => _bbb = value; }
        }
        public struct TstructA
        {
            public double value;
            TstructB _b;
            public TstructB b { get => _b; set => _b = value; }
        }
        public struct TstructB
        {
            public string kk;
            TstructC _c;
            public TstructC c { get => _c; set => _c = value; }
        }
        public struct TstructC
        {
            private int id;

            public int Id { get => id; set => id = value; }
        }
        public enum TestEnum
        {
            Test001 = 1,
            Test002 = 2,
            Test003 = 4,
            Test004 = 8,
            Test005 = 16,
            Test006 = 32,
            Test007 = 64,
            Test008 = 128,
        }
        public struct TClassPath
        {
            public TClassPath1 classPath1;
        }
        public struct TClassPath1
        {
            public TClassPath2 classPath2;
        }
        public struct TClassPath2
        {
            public TClassPath3 classPath3;
        }
        public struct TClassPath3
        {
            public TClassPath4 classPath4;
        }
        public struct TClassPath4
        {
            public TClass001 tClass001;
            public TClass003 testClassDD;
            public TClass003 testClassDD2;
            public TClass003 testClassDD3;
            public TClass003 testClassDD4;
        }
        public class TClass001
        {
            public object[] objects;
            private double testDuble;
            public double TestDuble
            {
                get { return testDuble; }
                set { testDuble = value; }
            }
            public TClass002 tClass002;
            private TClass002[] _tClass002s;
            public TClass002[] tClass002s { get => _tClass002s; set => _tClass002s = value; }
        }
        public class TClass002
        {
            public double size;
            public string testString;
            private TClass003 _tClass003;
            public TClass003 tClass003 { get => _tClass003; set => _tClass003 = value; }
            //public TClass003 tClass003;
            public TClass003[] tClass003s;

        }
        public class TClass003
        {
            public string testString;
        }
        public class TclassDCC
        {
            public TclassDCC(string str, IList<int> array, double num)
            {
                this.str = str;
                this.array = array;
                this.num = num;
            }
            public string str;
            public IList<int> array;
            public double num;
        }
        public struct TclassDCC3
        {
            public TclassDCC3(string str, IList<int> array, double num)
            {
                this.str = str;
                this.array = array;
                this.num = num;
            }
            public string str;
            public IList<int> array;
            public double num;
        }

    }
}
