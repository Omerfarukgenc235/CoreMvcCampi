﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class WriterManager :IWriterService

    {
        IWriterDal _writerdal;

        public WriterManager(IWriterDal writerdal)
        {
            _writerdal = writerdal;
        }
     
        public List<Writer> GetList()
        {
            return _writerdal.GetListAll();
        }

        public List<Writer> GetWriterByID(int id)
        {
            return _writerdal.GetListAll(X => X.WriterID == id);
        }

        public void TAdd(Writer t)
        {
            _writerdal.Insert(t);
        }

        public void TDelete(Writer t)
        {
            _writerdal.Delete(t);
        }

        public Writer TGetByID(int id)
        {
            return _writerdal.GetByID(id);
        }

        public void TUpdate(Writer t)
        {
            _writerdal.Update(t);
        }

        public void YazarYayinDurumu(Writer writer)
        {
            if(writer.WriterStatus == true)
            {
                writer.WriterStatus = false;
            }
            else
            {
                writer.WriterStatus = true;
            }
            _writerdal.Update(writer);
        }
    }
}