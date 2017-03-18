using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.DTO
{
    public class Bill
    {
        private int iD;

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }

        private DateTime? dateCheckIn;

        public DateTime? DateCheckIn
        {
            get { return dateCheckIn; }
            set { dateCheckIn = value; }
        }
        private DateTime? dateCheckOut;

        public DateTime? DateCheckOut
        {
            get { return dateCheckOut; }
            set { dateCheckOut = value; }
        }
        private int iDTable;

        public int IDTable
        {
            get { return iDTable; }
            set { iDTable = value; }
        }
        private int status;

        public int Status
        {
            get { return status; }
            set { status = value; }
        }
        private int discount;

        public int Discount
        {
            get { return discount; }
            set { discount = value; }
        }

        public Bill(int id, DateTime? datecheckin, DateTime? datecheckout, int idtable, int status, int discount)
        {
            this.ID = id;
            this.DateCheckIn = datecheckin;
            this.DateCheckOut = datecheckout;
            this.IDTable = idtable;
            this.Status = status;
            this.Discount = discount;
        }
        public Bill(DataRow row)
        {
            this.ID = (int)row["id"];
            this.DateCheckIn = (DateTime?)row["datecheckin"];
            var dataCheckOutTemp = row["datecheckout"];
            if(dataCheckOutTemp.ToString() != "")
                this.DateCheckOut = (DateTime?)dataCheckOutTemp;
            this.IDTable = (int)row["idtable"];
            this.Status = (int)row["status"];
            if (row["discount"].ToString() !="")
                this.Discount = (int)row["discount"];
        }
    }
}
