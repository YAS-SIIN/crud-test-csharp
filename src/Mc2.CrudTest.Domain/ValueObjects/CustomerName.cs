using CleanArchitecture.Domain.Common;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Domain.ValueObjects;

public class CustomerName : ValueObject
{
    public string Firstname { get; }
    public string Lastname { get; }
    public CustomerName(string firstname, string lastname)
    {
        if (string.IsNullOrWhiteSpace(firstname)) throw new ArgumentNullException(nameof(firstname));
        if (firstname.Length < 3) throw new ApplicationException("First name is invalid");

        if (string.IsNullOrWhiteSpace(lastname)) throw new ArgumentNullException(nameof(lastname));
        if (lastname.Length < 3) throw new ApplicationException("Last name is invalid");

        Firstname = firstname;
        Lastname = lastname;

    }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Firstname;
        yield return Lastname;
    }
}
