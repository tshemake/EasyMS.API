using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace EasyMS.API.Entities
{
    public class EasyMSList<T> : IEnumerable<T> where T : Entity
    {
        private readonly IEnumerable<T> _collection;

        public EasyMSList(IEnumerable<T> collection)
        {
            _collection = collection;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _collection.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _collection.GetEnumerator();
        }
    }
}
