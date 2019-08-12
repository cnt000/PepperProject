using System.Collections.Generic;
using NUnit.Framework;
using PepperProject;

namespace Tests
{
    public class GetLabelForItemSplittedTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void OneOccurrenceFirstTupleOnCode10()
        {
            var configuration = new Dictionary<string, Dictionary<string[], string[]>>
            {
                {
                    "code10", new Dictionary<string[], string[]>
                    {
                        {new[] {"100", "300", "500"}, new[] {"a", "b", "d.json"}},
                        {new[] {"1", "400", "50"}, new[] {"x", "y", "z.json"}}
                    }
                },
                {
                    "micro", new Dictionary<string[], string[]>
                    {
                        {new[] {"1", "30", "50"}, new[] {"a", "b", "f.json"}},
                        {new[] {"20", "40", "60"}, new[] {"x", "y", "j.json"}}
                    }
                },
                {
                    "macro", new Dictionary<string[], string[]>
                    {
                        {new[] {"1", "15", "15"}, new[] {"a", "b", "readytowear.json"}},
                        {new[] {"2", "4", "6"}, new[] {"x", "y", "z.json"}}
                    }
                }
            };

            var ids = new Dictionary<string, string>
            {
                {"code10", "100"},
                {"micro", "2"},
                {"macro", "3"}
            };

            var label = GetLabelForDimensions.GetLabelForItemSplitted(ids, configuration);

            StringAssert.AreEqualIgnoringCase(label, "a/b/d.json", "OneOccurrenceFirstTupleOnCode10");
        }

        [Test]
        public void OneOccurrenceFirstTupleOnMicro()
        {
            var configuration = new Dictionary<string, Dictionary<string[], string[]>>
            {
                {
                    "code10", new Dictionary<string[], string[]>
                    {
                        {new[] {"100", "300", "500"}, new[] {"a", "b", "d.json"}},
                        {new[] {"1", "400", "50"}, new[] {"x", "y", "z.json"}}
                    }
                },
                {
                    "micro", new Dictionary<string[], string[]>
                    {
                        {new[] {"1", "199", "30"}, new[] {"a", "b", "f.json"}},
                        {new[] {"20", "40", "60"}, new[] {"x", "y", "j.json"}}
                    }
                },
                {
                    "macro", new Dictionary<string[], string[]>
                    {
                        {new[] {"9", "15", "15"}, new[] {"a", "b", "readytowear.json"}},
                        {new[] {"2", "4", "6"}, new[] {"x", "y", "z.json"}}
                    }
                }
            };

            var ids = new Dictionary<string, string>
            {
                {"code10", "30"},
                {"micro", "199"},
                {"macro", "3"}
            };

            var label = GetLabelForDimensions.GetLabelForItemSplitted(ids, configuration);

            StringAssert.AreEqualIgnoringCase(label, "a/b/f.json", "OneOccurrenceFirstTupleOnMicro");
        }

        [Test]
        public void OneOccurrenceFirstTupleOnMacro()
        {
            var configuration = new Dictionary<string, Dictionary<string[], string[]>>
            {
                {
                    "code10", new Dictionary<string[], string[]>
                    {
                        {new[] {"100", "300", "500"}, new[] {"a", "b", "d.json"}},
                        {new[] {"1", "400", "50"}, new[] {"x", "y", "z.json"}}
                    }
                },
                {
                    "micro", new Dictionary<string[], string[]>
                    {
                        {new[] {"1", "30", "50"}, new[] {"a", "b", "f.json"}},
                        {new[] {"20", "40", "60"}, new[] {"x", "y", "j.json"}}
                    }
                },
                {
                    "macro", new Dictionary<string[], string[]>
                    {
                        {new[] {"1", "15", "112"}, new[] {"a", "b", "readytowear.json"}},
                        {new[] {"2", "4", "6"}, new[] {"x", "y", "z.json"}}
                    }
                }
            };

            //string[] ids = {"15", "2", "112"};
            var ids = new Dictionary<string, string>
            {
                {"code10", "15"},
                {"micro", "2"},
                {"macro", "112"}
            };

            var label = GetLabelForDimensions.GetLabelForItemSplitted(ids, configuration);

            StringAssert.AreEqualIgnoringCase(label, "a/b/readytowear.json", "OneOccurrenceFirstTupleOnMacro");
        }

        [Test]
        public void OneOccurrenceSecondTupleOnCode10()
        {
            var configuration = new Dictionary<string, Dictionary<string[], string[]>>
            {
                {
                    "code10", new Dictionary<string[], string[]>
                    {
                        {new[] {"100", "300", "500"}, new[] {"a", "b", "d.json"}},
                        {new[] {"1777", "400", "50"}, new[] {"x", "y", "z.json"}}
                    }
                },
                {
                    "micro", new Dictionary<string[], string[]>
                    {
                        {new[] {"111", "30", "50"}, new[] {"a", "b", "f.json"}},
                        {new[] {"20", "40", "60"}, new[] {"x", "y", "j.json"}}
                    }
                },
                {
                    "macro", new Dictionary<string[], string[]>
                    {
                        {new[] {"1", "15", "15"}, new[] {"a", "b", "readytowear.json"}},
                        {new[] {"2", "4", "6"}, new[] {"x", "y", "z.json"}}
                    }
                }
            };

            //string[] ids = {"1777", "2", "3"};
            var ids = new Dictionary<string, string>
            {
                {"code10", "1777"},
                {"micro", "2"},
                {"macro", "3"}
            };

            var label = GetLabelForDimensions.GetLabelForItemSplitted(ids, configuration);

            StringAssert.AreEqualIgnoringCase(label, "x/y/z.json", "OneOccurrenceSecondTupleOnCode10");
        }

        [Test]
        public void OneOccurrenceSecondTupleOnMicro()
        {
            var configuration = new Dictionary<string, Dictionary<string[], string[]>>
            {
                {
                    "code10", new Dictionary<string[], string[]>
                    {
                        {new[] {"100", "300", "500"}, new[] {"a", "b", "d.json"}},
                        {new[] {"1", "400", "50"}, new[] {"x", "y", "z.json"}}
                    }
                },
                {
                    "micro", new Dictionary<string[], string[]>
                    {
                        {new[] {"1", "30", "50"}, new[] {"a", "b", "f.json"}},
                        {new[] {"20", "4550", "60"}, new[] {"x", "y", "j.json"}}
                    }
                },
                {
                    "macro", new Dictionary<string[], string[]>
                    {
                        {new[] {"1", "15", "15"}, new[] {"a", "b", "readytowear.json"}},
                        {new[] {"2", "4", "6"}, new[] {"x", "y", "z.json"}}
                    }
                }
            };

            var ids = new Dictionary<string, string>
            {
                {"code10", "40"},
                {"micro", "4550"},
                {"macro", "3"}
            };

            var label = GetLabelForDimensions.GetLabelForItemSplitted(ids, configuration);

            StringAssert.AreEqualIgnoringCase(label, "x/y/j.json", "OneOccurrenceSecondTupleOnMicro");
        }

        [Test]
        public void OneOccurrenceSecondTupleOnMacro()
        {
            var configuration = new Dictionary<string, Dictionary<string[], string[]>>
            {
                {
                    "code10", new Dictionary<string[], string[]>
                    {
                        {new[] {"100", "300", "500"}, new[] {"a", "b", "d.json"}},
                        {new[] {"1", "400", "50"}, new[] {"x", "y", "z.json"}}
                    }
                },
                {
                    "micro", new Dictionary<string[], string[]>
                    {
                        {new[] {"1", "30", "50"}, new[] {"a", "b", "f.json"}},
                        {new[] {"20", "40", "60"}, new[] {"x", "y", "j.json"}}
                    }
                },
                {
                    "macro", new Dictionary<string[], string[]>
                    {
                        {new[] {"1", "15", "15"}, new[] {"a", "b", "readytowear.json"}},
                        {new[] {"2", "4", "6789"}, new[] {"x", "y", "z.json"}}
                    }
                }
            };

            //string[] ids = {"6", "2", "6789"};
            var ids = new Dictionary<string, string>
            {
                {"code10", "6"},
                {"micro", "2"},
                {"macro", "6789"}
            };

            var label = GetLabelForDimensions.GetLabelForItemSplitted(ids, configuration);

            StringAssert.AreEqualIgnoringCase(label, "x/y/z.json", "OneOccurrenceSecondTupleOnMacro");
        }

        [Test]
        public void TwoOccurrencesFirstTupleOnCode10AndMicroWinMicro()
        {
            var configuration = new Dictionary<string, Dictionary<string[], string[]>>
            {
                {
                    "code10", new Dictionary<string[], string[]>
                    {
                        {new[] {"1001", "300", "500"}, new[] {"a", "b", "d.json"}},
                        {new[] {"1", "400", "50"}, new[] {"x", "y", "z.json"}}
                    }
                },
                {
                    "micro", new Dictionary<string[], string[]>
                    {
                        {new[] {"765", "100", "50"}, new[] {"a", "b", "f.json"}},
                        {new[] {"20", "40", "60"}, new[] {"x", "y", "j.json"}}
                    }
                },
                {
                    "macro", new Dictionary<string[], string[]>
                    {
                        {new[] {"1", "15", "15"}, new[] {"a", "b", "readytowear.json"}},
                        {new[] {"2", "4", "6789"}, new[] {"x", "y", "z.json"}}
                    }
                }
            };

            var ids = new Dictionary<string, string>
            {
                {"code10", "1001"},
                {"micro", "100"},
                {"macro", "9999"}
            };

            var label = GetLabelForDimensions.GetLabelForItemSplitted(ids, configuration);
            StringAssert.AreEqualIgnoringCase(label, "a/b/f.json", "TwoOccurrencesFirstTupleOnCode10AndMicroWinMicro");
        }

        [Test]
        public void TwoOccurrencesFirstTupleOnMicroAndMacroWinMacro()
        {
            var configuration = new Dictionary<string, Dictionary<string[], string[]>>
            {
                {
                    "code10", new Dictionary<string[], string[]>
                    {
                        {new[] {"100", "300", "500"}, new[] {"a", "b", "d.json"}},
                        {new[] {"1", "400", "50"}, new[] {"x", "y", "z.json"}}
                    }
                },
                {
                    "micro", new Dictionary<string[], string[]>
                    {
                        {new[] {"1", "303030", "50"}, new[] {"a", "b", "f.json"}},
                        {new[] {"20", "40", "60"}, new[] {"x", "y", "j.json"}}
                    }
                },
                {
                    "macro", new Dictionary<string[], string[]>
                    {
                        {new[] {"1", "15", "404040"}, new[] {"a", "b", "readytowear.json"}},
                        {new[] {"2", "4", "6789"}, new[] {"x", "y", "z.json"}}
                    }
                }
            };
            var ids = new Dictionary<string, string>
            {
                {"code10", "6"},
                {"micro", "303030"},
                {"macro", "404040"}
            };
            var label = GetLabelForDimensions.GetLabelForItemSplitted(ids, configuration);
            StringAssert.AreEqualIgnoringCase(label, "a/b/readytowear.json",
                "TwoOccurrencesFirstTupleOnMicroAndMacroWinMacro");
        }

        [Test]
        public void ThreeOccurrencesFirstTupleOnCode10AndMicroAndMacroWinMacro()
        {
            var configuration = new Dictionary<string, Dictionary<string[], string[]>>
            {
                {
                    "code10", new Dictionary<string[], string[]>
                    {
                        {new[] {"33333", "300", "500"}, new[] {"a", "b", "d.json"}},
                        {new[] {"1", "400", "50"}, new[] {"x", "y", "z.json"}}
                    }
                },
                {
                    "micro", new Dictionary<string[], string[]>
                    {
                        {new[] {"1", "44444", "50"}, new[] {"a", "b", "f.json"}},
                        {new[] {"20", "40", "60"}, new[] {"x", "y", "j.json"}}
                    }
                },
                {
                    "macro", new Dictionary<string[], string[]>
                    {
                        {new[] {"1", "15", "55555"}, new[] {"a", "b", "readytowear.json"}},
                        {new[] {"2", "4", "6789"}, new[] {"x", "y", "z.json"}}
                    }
                }
            };
            var ids = new Dictionary<string, string>
            {
                {"code10", "33333"},
                {"micro", "44444"},
                {"macro", "55555"}
            };
            var label = GetLabelForDimensions.GetLabelForItemSplitted(ids, configuration);
            StringAssert.AreEqualIgnoringCase(label, "a/b/readytowear.json",
                "ThreeOccurrencesFirstTupleOnCode10AndMicroAndMacroWinMacro");
        }

        [Test]
        public void TwoOccurrencesSecondTupleOnCode10AndMicroWinMicro()
        {
            var configuration = new Dictionary<string, Dictionary<string[], string[]>>
            {
                {
                    "code10", new Dictionary<string[], string[]>
                    {
                        {new[] {"100", "300", "500"}, new[] {"a", "b", "d.json"}},
                        {new[] {"11111", "400", "50"}, new[] {"x", "y", "z.json"}}
                    }
                },
                {
                    "micro", new Dictionary<string[], string[]>
                    {
                        {new[] {"1", "30", "50"}, new[] {"a", "b", "f.json"}},
                        {new[] {"20", "22222", "60"}, new[] {"x", "y", "j.json"}}
                    }
                },
                {
                    "macro", new Dictionary<string[], string[]>
                    {
                        {new[] {"1", "15", "15"}, new[] {"a", "b", "readytowear.json"}},
                        {new[] {"2", "4", "6789"}, new[] {"x", "y", "z.json"}}
                    }
                }
            };
            var ids = new Dictionary<string, string>
            {
                {"code10", "11111"},
                {"micro", "22222"},
                {"macro", "999999"}
            };
            var label = GetLabelForDimensions.GetLabelForItemSplitted(ids, configuration);
            StringAssert.AreEqualIgnoringCase(label, "x/y/j.json", "TwoOccurrencesSecondTupleOnCode10AndMicroWinMicro");
        }

        [Test]
        public void TwoOccurrencesSecondTupleOnMicroAndMacroWinMacro()
        {
            var configuration = new Dictionary<string, Dictionary<string[], string[]>>
            {
                {
                    "code10", new Dictionary<string[], string[]>
                    {
                        {new[] {"100", "300", "500"}, new[] {"a", "b", "d.json"}},
                        {new[] {"1", "400", "50"}, new[] {"x", "y", "z.json"}}
                    }
                },
                {
                    "micro", new Dictionary<string[], string[]>
                    {
                        {new[] {"1", "30", "50"}, new[] {"a", "b", "f.json"}},
                        {new[] {"20", "22222", "60"}, new[] {"x", "y", "j.json"}}
                    }
                },
                {
                    "macro", new Dictionary<string[], string[]>
                    {
                        {new[] {"1", "15", "15"}, new[] {"a", "b", "readytowear.json"}},
                        {new[] {"2", "4", "33333"}, new[] {"x", "y", "z.json"}}
                    }
                }
            };
            var ids = new Dictionary<string, string>
            {
                {"code10", "99999"},
                {"micro", "22222"},
                {"macro", "33333"}
            };
            var label = GetLabelForDimensions.GetLabelForItemSplitted(ids, configuration);
            StringAssert.AreEqualIgnoringCase(label, "x/y/z.json", "TwoOccurrencesSecondTupleOnMicroAndMacroWinMacro");
        }

        [Test]
        public void ThreeOccurrencesSecondTupleOnCode10AndMicroAndMacroWinMacro()
        {
            var configuration = new Dictionary<string, Dictionary<string[], string[]>>
            {
                {
                    "code10", new Dictionary<string[], string[]>
                    {
                        {new[] {"100", "300", "500"}, new[] {"a", "b", "d.json"}},
                        {new[] {"1", "44444", "50"}, new[] {"x", "y", "z.json"}}
                    }
                },
                {
                    "micro", new Dictionary<string[], string[]>
                    {
                        {new[] {"1", "30", "50"}, new[] {"a", "b", "f.json"}},
                        {new[] {"55555", "40", "60"}, new[] {"x", "y", "j.json"}}
                    }
                },
                {
                    "macro", new Dictionary<string[], string[]>
                    {
                        {new[] {"1", "15", "15"}, new[] {"a", "b", "readytowear.json"}},
                        {new[] {"2", "4", "66666"}, new[] {"x", "y", "z.json"}}
                    }
                }
            };
            var ids = new Dictionary<string, string>
            {
                {"code10", "44444"},
                {"micro", "55555"},
                {"macro", "66666"}
            };
            var label = GetLabelForDimensions.GetLabelForItemSplitted(ids, configuration);
            StringAssert.AreEqualIgnoringCase(label, "x/y/z.json",
                "ThreeOccurrencesSecondTupleOnCode10AndMicroAndMacroWinMacro");
        }
    }
}