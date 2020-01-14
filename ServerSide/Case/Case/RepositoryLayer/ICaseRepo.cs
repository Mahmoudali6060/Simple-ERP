using Case.DTOs;
using Shared.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Text;


namespace Case.RepositoryLayer
{
   public interface ICaseRepo :  ICRUDOperationsRepo<CasesDTO>
    {
    }
}
