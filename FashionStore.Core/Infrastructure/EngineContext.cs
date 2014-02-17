using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionStore.Core.Infrastructure
{
    public class EngineContext
    {
        public static FsEngine Initialize(bool forceRecreate)
        {
            if (Singleton<FsEngine>.Instance == null)
            {
                Singleton<FsEngine>.Instance = new FsEngine();
            }

            return Singleton<FsEngine>.Instance;
        }

        public static FsEngine Current
        {
            get
            {
                if (Singleton<FsEngine>.Instance == null)
                {
                    Initialize(false);
                }
                return Singleton<FsEngine>.Instance;
            }
        }
    }
}
