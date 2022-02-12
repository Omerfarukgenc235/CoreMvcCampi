using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CommentManager : ICommentService
    {
        ICommentDal _commentdal;

        public CommentManager(ICommentDal commentdal)
        {
            _commentdal = commentdal;
        }

        public void AddComment(Comment comment)
        {
            _commentdal.Insert(comment);
        }

        public List<Comment> ButunYorumlar()
        {
            return _commentdal.GetListWithBlog();
        }

        public List<Comment> GetList(int id)
        {
          return  _commentdal.GetListAll(x => x.BlogID == id);
        }

        public Comment TGetByID(int id)
        {
            return _commentdal.GetByID(id);
        }

        public void TUpdate(Comment comment)
        {
            if(comment.CommentStatus == true)
            {
                comment.CommentStatus = false;
            }
            else
            {
                comment.CommentStatus = true;
            }
            _commentdal.Update(comment);
        }
    }
}
