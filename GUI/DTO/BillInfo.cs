using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.DTO
{
    public class BillInfo
    {
        private int iD;

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }

        private int iDBill;

        public int IdBill
        {
            get { return iDBill; }
            set { iDBill = value; }
        }

        private int idFood;

        public int IdFood
        {
            get { return idFood; }
            set { idFood = value; }
        }

        private int count;

        public int Count
        {
            get { return count; }
            set { count = value; }
        }

        public BillInfo(int id, int billid, int idfood, int count)
        {
            this.ID = id;
            this.IdBill = billid;
            this.IdFood = idfood;
            this.Count = count;
        }

        public BillInfo(DataRow row)
        {
            this.ID = (int)row["id"];
            this.IdBill = (int)row["idbill"];
            this.IdFood = (int)row["idfood"];
            this.Count = (int)row["count"];
        }
    }
}
