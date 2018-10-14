using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KattisUtilities
{
    public struct Language
    {
        public string Lang;
        public string Extension;
       

    }
    public class Constants
    {
        public static SortedDictionary<string,string> Languages { get; protected set; } = 
            new SortedDictionary<string,string>() {
                    {".c#",       "C#"          },
                    {".cs",       "C#"          },
                    {".c",        "C++"         },
                    {".cpp",      "C++"         },
                    {".cxx",      "C++"         },
                    {".h",        "C++"         },
                    {".go",       "Go"          },
                    {".hs",       "Haskel"      },
                    {".java",     "Java"        },
                    {".js",       "JavaScript"  },
                    {".m",        "Objective-C" },
                    {".pas",      "Pascal"      },
                    {".php",      "PHP"         },
                    {".pas",      "Pascal"      },
                    {".pl",       "Prolog"      },
                    {".py",       "Python"      },
                    {".rb",       "Ruby"        }
        };
        public  Constants()
        {
            
           

        }
        
    }
}
