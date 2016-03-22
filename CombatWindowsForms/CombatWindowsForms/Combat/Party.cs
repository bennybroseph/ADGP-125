using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BennyBroseph.Contextual;

namespace Combat
{
    public sealed class Controller : Singleton<Controller>
    {
        private List<List<ICombatable<float>>> m_Parties;
        
        public Controller()
        {

        }
    }
}
