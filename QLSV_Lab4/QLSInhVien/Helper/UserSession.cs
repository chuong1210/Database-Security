using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace QLSInhVien.Helper
{
    public static class UserSession
    {
        public static string PublicKeySession { get; set; } = "<RSAKeyValue><Modulus>0fCQgGR4XHrcC2V2g0c91O5znt9cYMsJz81EmhM35iOIkCVNe8KyruCYNQkTb9Ru83A90glOToyl9PszrY4tBQ==</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
        public static string PriKeySession { get; set; } = "<RSAKeyValue><Modulus>0fCQgGR4XHrcC2V2g0c91O5znt9cYMsJz81EmhM35iOIkCVNe8KyruCYNQkTb9Ru83A90glOToyl9PszrY4tBQ==</Modulus><Exponent>AQAB</Exponent><P>4pXyL6VrBGGSFBMvCUZEjt3+48TxVcMmWQf0peYUyW8=</P><Q>7TFtINuTxOQEk6wRuPzbFDdqzj/R8XpWafDMUZnnrss=</Q><DP>DXvW2bcCU1RrGP67QdYIpmfXjz5dDjl6wrmSeXzjp8k=</DP><DQ>PjBqW2YW3VWneYxw7R6m1isdfswu4HBh/c7b0z1WCHc=</DQ><InverseQ>Z42G7X5X7QKcyxRP2saxgd6YWQmxoNySUD5f2rUf2nA=</InverseQ><D>Yi/LtXDH5iDD50SV8AISxhKb2rMGZnKvbRPIwPK6ExS0cpo+nh2gfdDJ+JwucuU/7+BJ5ECbL3ypoWOvH3TlBQ==</D></RSAKeyValue>";
        public static RSAParameters PublicKeyParamerterSession { get; set; }

        public static RSAParameters PrivateKeyParamerterSession { get; set; }
    }

}
