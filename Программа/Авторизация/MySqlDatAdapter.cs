using System;
using System.Data;

namespace Авторизация
{
    internal class MySqlDatAdapter
    {
        public object Selectcommand { get; internal set; }

        internal void Fill(DataTable table)
        {
            throw new NotImplementedException();
        }
    }
}