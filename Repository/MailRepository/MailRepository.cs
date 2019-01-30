using Core.RepositoryBase;
using Model.Models;
using System;

namespace Repository.MailRepository
{
    public class MailRepository : Repository<MailTo, Guid>, IMailRepository
    {
    }
}
