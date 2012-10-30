///<summary>
/// Classe contendo a implementação para cifrar e decifrar simetricamente o conteudo
/// 
/// @author Fabio Augusto
///</summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using sacis.model.excecao;

namespace sacis.model.criptografia
{
    public class simetrica
    {
        private static string tipoSimetrica = "SHA256";
        //private static string vetorInicializacao = "@1B2c3D4e5F6g7H8";
        private static string MSG_CHAVE_INVALIDA = "Chave Invalida!";
        private const int N = 624;
        private const int M = 397;
        private static ulong[] mt = new ulong[N];
        private static int mti = N + 1;
        private static ulong[] matriz = {0x0,0x9908b0df};
        private static string chave;

        ///<summary>
        /// 
        /// Metodo para gerar o hash de uma string aleatoria
        /// 
        ///</summary>
        public static string geraSenha(){

            return hash.hashing(geradorCadeiaCaracteres());
        
        }

        ///<summary>
        ///
        /// Metodo contendo algoritmo gerador de numeros aleatorios entre 0 e 127
        /// 
        ///</summary>
        private static ulong geradorNumerosAleatorios(uint i)
        {

            mt[0] = i & 0xffffffffU;

            for (mti = 1; mti < N; mti++) mt[mti] = (69069 * mt[mti - 1]) & 0xffffffffU;

            ulong y;

            if (mti >= N)
            {
                int kk;

                for (kk = 0; kk < N - M; kk++)
                {
                    y = (mt[kk] & 0x80000000) | (mt[kk + 1] & 0x7fffffff);
                    mt[kk] = mt[kk + M] ^ (y >> 1) ^ matriz[y & 0x1];
                }

                for (; kk < N - 1; kk++)
                {
                    y = (mt[kk] & 0x80000000) | (mt[kk + 1] & 0x7fffffff);
                    mt[kk] = mt[kk + (M - N)] ^ (y >> 1) ^ matriz[y & 0x1];
                }

                y = (mt[N - 1] & 0x80000000) | (mt[0] & 0x7fffffff);
                mt[N - 1] = mt[M - 1] ^ (y >> 1) ^ matriz[y & 0x1];

                mti = 0;

            }

            uint usado = 127;
            usado |= usado >> 1;
            usado |= usado >> 2;
            usado |= usado >> 4;
            usado |= usado >> 8;
            usado |= usado >> 16;

            ulong ret;

            do
            {
                y = mt[mti++];
                y ^= (y >> 11);
                y ^= (y >> 7) & 0x9d2c5680;
                y ^= (y >> 15) & 0xefc60000;
                y ^= (y >> 18);

                ret = y & usado;

            } while (ret > 127);

            return ret;
        }
        
        ///<summary>
        ///
        /// Metodo contendo algoritmo gerador de uma cadeia de caracteres com 32 caracteres
        /// 
        ///</summary>
        private static string geradorCadeiaCaracteres()
        {
            string final = "";

            Random seed = new Random(DateTime.Now.Millisecond);

            for (int i = 0; i < 32; i++)
            {
                uint f = Convert.ToUInt32(seed.Next(0, 999999999));
                ulong u = geradorNumerosAleatorios(f);
                final += (char)u;
            }

            return final;
        }

        ///<summary>
        /// 
        /// Metodo para gerar IV aleatoriamente de 16 caracteres
        /// 
        ///</summary>
        private static string geradorIV()
        {
            string vetor = hash.hashing(geradorCadeiaCaracteres());
            return vetor.Substring(0, 16); 
        }

        ///<summary>
        ///
        /// Metodo para cifrar arquivos localmente
        /// 
        ///</summary>
        public static string cifraArquivosLocais(string chave, string conteudo) 
        {         
            return criptografar(chave, conteudo);        
        }

        ///<summary>
        ///
        /// Metodo para decifrar arquivos localmente
        /// 
        ///</summary>
        public static string decifraArquivosLocais(string chave, string conteudo)
        {
            return descriptografar(chave, conteudo);
        }

        ///<summary>
        ///
        /// Metodo para cifrar mensagens
        /// 
        ///</summary>
        public static string cifraMensagem(string conteudo)
        {
            string chave = geradorCadeiaCaracteres();
            string cripto = criptografar(chave, conteudo);

            return chave + cripto;
        }

        ///<summary>
        ///
        /// Metodo para decifrar mensagens
        /// 
        ///</summary>
        public static string decifraMensagem(string conteudo)
        {
            string chave = conteudo.Substring(0, 32);
            conteudo = conteudo.Remove(0, 32);

            return descriptografar(chave, conteudo);
        }

        ///<summary>
        ///
        /// Metodo contendo algoritmo de criptografia simetrica Rijndael
        /// 
        ///</summary>
        private static string criptografar(string chave, string conteudo)
        {
            try{

                string vetorInicializacao = geradorIV();                

                byte[] vetorInicializacaoBytes = Encoding.ASCII.GetBytes(vetorInicializacao);
                byte[] saltBytes = Encoding.ASCII.GetBytes(chave.Length.ToString());
                byte[] conteudoBytes = Encoding.UTF8.GetBytes(conteudo);

                PasswordDeriveBytes senha = new PasswordDeriveBytes(chave, saltBytes, tipoSimetrica, 2);

                byte[] senhaBytes = senha.GetBytes(256/8);

                RijndaelManaged rijndael = new RijndaelManaged();
                rijndael.Mode = CipherMode.CBC;

                ICryptoTransform encriptador = rijndael.CreateEncryptor(senhaBytes, vetorInicializacaoBytes);

                MemoryStream backup = new MemoryStream();

                CryptoStream fluxo = new CryptoStream(backup, encriptador, CryptoStreamMode.Write);
                fluxo.Write(conteudoBytes, 0, conteudoBytes.Length);
                fluxo.FlushFinalBlock();
     
                byte[] textoCifradoBytes = backup.ToArray();

                backup.Close();
                fluxo.Close();

                string textoCifrado = Convert.ToBase64String(textoCifradoBytes);

                return vetorInicializacao + textoCifrado;

            }
            catch (CryptographicException cripto)
            {                
                throw new excecao.excecao(MSG_CHAVE_INVALIDA);
            }
            catch (NullReferenceException nre)
            {
                throw new excecao.excecao(MSG_CHAVE_INVALIDA);
            }
        }

        ///<summary>
        ///
        /// Metodo contendo algoritmo de descriptografia simetrica Rijndael
        /// 
        ///</summary>
        private static string descriptografar(string chave, string conteudo)
        {
            try
            {
                string vetorInicializacao = conteudo.Substring(0, 16);
                conteudo = conteudo.Remove(0, 16);

                byte[] vetorInicializacaoBytes = Encoding.ASCII.GetBytes(vetorInicializacao);
                byte[] saltBytes = Encoding.ASCII.GetBytes(chave.Length.ToString());
                byte[] conteudoBytes = Convert.FromBase64String(conteudo);

                PasswordDeriveBytes senha = new PasswordDeriveBytes(chave, saltBytes, tipoSimetrica, 2);

                byte[] senhaBytes = senha.GetBytes(256 / 8);

                RijndaelManaged rijndael = new RijndaelManaged();
                rijndael.Mode = CipherMode.CBC;

                ICryptoTransform descriptador = rijndael.CreateDecryptor(senhaBytes, vetorInicializacaoBytes);

                MemoryStream backup = new MemoryStream(conteudoBytes);

                CryptoStream fluxo = new CryptoStream(backup, descriptador, CryptoStreamMode.Read);

                byte[] textoClaroBytes = new byte[conteudoBytes.Length];

                int contador = fluxo.Read(textoClaroBytes, 0, textoClaroBytes.Length);
                backup.Close();
                fluxo.Close();

                string textoClaro = Encoding.UTF8.GetString(textoClaroBytes, 0, contador);

                return textoClaro;
            }
            catch (CryptographicException cripto)
            {                
                throw new excecao.excecao(MSG_CHAVE_INVALIDA);
            }
            catch (NullReferenceException nre)
            {
                throw new excecao.excecao(MSG_CHAVE_INVALIDA);
            }

        }
        
    }
}
