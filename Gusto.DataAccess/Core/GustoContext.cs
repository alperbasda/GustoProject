using System;
using System.Data.Entity;
using Gusto.Entities.BaseTypes;

namespace Gusto.DataAccess.Core
{
    public class GustoContext : DbContext
    {

        public IDbSet<Domain> Domains { get; set; }
        
        public GustoContext()
            :base("DomainTakip")
        {
            
        }
    }
}