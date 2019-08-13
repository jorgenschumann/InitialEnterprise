using InitialEnterprise.Infrastructure.DDD.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InitialEnterprise.Domain.MainBoundedContext.CreditCardModule.Aggreate
{    
    public class CreditCardType : Enumeration
    {
        public static CreditCardType AmericanExpress = new CreditCardType(1, nameof(AmericanExpress));
        public static CreditCardType Visa = new CreditCardType(2, nameof(Visa));
        public static CreditCardType MasterCard = new CreditCardType(3, nameof(MasterCard));
        public static CreditCardType CarteBlanche = new CreditCardType(4, nameof(CarteBlanche));
        public static CreditCardType DinersClub = new CreditCardType(5, nameof(DinersClub));
        public static CreditCardType Discover = new CreditCardType(6, nameof(Discover));
        public static CreditCardType Enroute = new CreditCardType(7, nameof(Enroute));
        public static CreditCardType JCB = new CreditCardType(8, nameof(JCB));
        public static CreditCardType Maestro = new CreditCardType(9, nameof(Maestro));
        public static CreditCardType Solo = new CreditCardType(10, nameof(Solo));
        public static CreditCardType Switch = new CreditCardType(11, nameof(Switch));
        public static CreditCardType VisaElectron = new CreditCardType(12, nameof(VisaElectron));

        protected CreditCardType()
        {
        }

        public CreditCardType(int id, string name) : base(id, name)
        {
        }

        public static IEnumerable<CreditCardType> List()
        {
            return new[] { AmericanExpress, Visa, MasterCard, CarteBlanche, DinersClub, Discover, Enroute, JCB , Maestro, Solo, Switch , VisaElectron };
        }

        public static CreditCardType FromName(string name)
        {
            var state = List().SingleOrDefault(s => string.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));

            if (state == null)
            {
                throw new ArgumentException($"Possible values for CreditCardType: {string.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }

        public static CreditCardType From(int id)
        {
            var state = List().SingleOrDefault(s => s.Id == id);

            if (state == null)
            {
                throw new ArgumentException($"Possible values for CreditCardType: {string.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }
    }
}
