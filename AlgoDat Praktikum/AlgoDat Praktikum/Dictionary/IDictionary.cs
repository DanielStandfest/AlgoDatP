using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    public interface IDictionary
    {
        bool Search(int elem);
        bool Insert(int elem);
        bool Delete(int elem);
        void Print();
    }

    #region Unsorted
    public interface IMultiSet : IDictionary { }

    public interface ISet : IMultiSet { }
    #endregion

    #region Sorted
    public interface IMultiSetSorted : IDictionary { }

    public interface ISetSorted : IMultiSetSorted { }
    #endregion
}
