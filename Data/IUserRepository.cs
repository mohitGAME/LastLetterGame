using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcLastLetter.Data
{
    public interface ILastLetterRepository
    {
        UserList GetUsers();  
        void CreateUser(User yrs);

    }
}