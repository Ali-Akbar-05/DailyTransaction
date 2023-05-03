using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums;

public enum MathematicalType
{
    Positive=1,
    Negetive=-1
}

public static class SystemRoles
{
    public static string superAdmin = "Super Admin";
    public static string admin = "Admin";
    public static string manager = "Manager";
    public static string user = "User";

}

