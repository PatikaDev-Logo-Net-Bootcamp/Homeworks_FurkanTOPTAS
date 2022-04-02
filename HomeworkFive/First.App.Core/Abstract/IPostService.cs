using First.App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace First.App.Business.Abstract
{
    public interface IPostService
    {
        List<Post> GetAllPost();
        void AddPost(Post post);
    }
}
