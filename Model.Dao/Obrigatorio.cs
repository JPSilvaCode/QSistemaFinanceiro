using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public interface Obrigatorio<qualquerClasse>
    {
        void Create(qualquerClasse obj);
        void Delete(qualquerClasse obj);
        void Update(qualquerClasse obj);
        bool Find(qualquerClasse obj);
        List<qualquerClasse> FindAll();
    }
}
