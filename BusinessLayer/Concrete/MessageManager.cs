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
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public List<Message2> GetList()
        {
            return _messageDal.GetListAll();
        }

        public List<Message2> GetInboxByWriter(int id)
        {
            return _messageDal.GetListWithMessageByWriter(id);

        }

        public void TAdd(Message2 t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Message2 t)
        {
            throw new NotImplementedException();
        }

        public Message2 TGetByID(int id)
        {
            return _messageDal.GetByID(id);

        }

        public void TUpdate(Message2 t)
        {
            throw new NotImplementedException();
        }
    }
}