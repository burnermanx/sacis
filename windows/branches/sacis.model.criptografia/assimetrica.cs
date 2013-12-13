///<summary>
/// Classe para implementação dos metodos para a criptografia assimetrica 
///
/// @author Fabio Augusto 
///</summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using sacis.model.excecao;
using System.Security.Cryptography;
using Org.BouncyCastle.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.OpenSsl;
using System.IO;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;

namespace sacis.model.criptografia
{
    public class assimetrica
    {
        private static string MSG_CERTIFICADO = "Certificado Inválido ou com senha!";
        private static string MSG_CERTIFICADO_INEXISTENTE = "Certificado Inválido!";
        private static string MSG_CHAVE_INVALIDA = "Chave Informada Inválida!";
        private static string MD5 = "MD5WithRSAEncryption";

        ///<summary>
        ///
        /// Método que retorna a data da expiração da chave certificada
        /// através do caminho passado.
        /// 
        /// Retorna excecao: Certificado Inválido ou com senha
        /// 
        ///</summary>
        public static string dataExpiracao(string caminho) {

            try
            {
                    X509Certificate2 data = new X509Certificate2(caminho);
                    return data.GetExpirationDateString();

            } catch (CryptographicException ce) {
            
                throw new excecao.excecao(MSG_CERTIFICADO);

            } catch (ArgumentException ae) {

                throw new excecao.excecao(MSG_CERTIFICADO_INEXISTENTE);

            }
        
        }

        ///<summary>
        ///
        /// Metodo para criptografia assimétrica RSA utilizando BouncyCastle
        /// 
        ///</summary>
        public static string cifraAssimetrica(string caminhoChave, string conteudoClaro) 
        {
            try
            {
                byte[] conteudoBytes = Encoding.UTF8.GetBytes(conteudoClaro);

                //lendo certificado
                AsymmetricKeyParameter certificadoParametros = retornaParametrosCertificado(caminhoChave);

                //cifrando texto
                IAsymmetricBlockCipher cifra = new RsaEngine();
                cifra.Init(true, certificadoParametros);
                byte[] conteudoCifrado = cifra.ProcessBlock(conteudoBytes, 0, conteudoBytes.Length);

                //Converte pra base64
                string conteudoBase64 = Convert.ToBase64String(conteudoCifrado);

                return conteudoBase64;
            }
            catch (excecao.excecao ex)
            {
                throw new excecao.excecao(MSG_CHAVE_INVALIDA);
            }
        }

        ///<summary>
        ///
        /// Metodo para descriptografia assimétrica RSA utilizando BouncyCastle
        /// 
        ///</summary>
        public static string decifraAssimetrica(string caminhoChave, string conteudoCifrado)
        {
            try
            {
                byte[] conteudoCifradoBytes = Convert.FromBase64String(conteudoCifrado);

                //lendo chave privada                
                AsymmetricCipherKeyPair chavePrivadaParametros = retornaParametrosChavePrivada(caminhoChave);

                //decifrando texto
                IAsymmetricBlockCipher decifra = new RsaEngine();
                decifra.Init(false, chavePrivadaParametros.Private);
                byte[] conteudoDecifradoBytes = decifra.ProcessBlock(conteudoCifradoBytes, 0, conteudoCifradoBytes.Length);

                string conteudoDecifrado = Encoding.UTF8.GetString(conteudoDecifradoBytes);

                return conteudoDecifrado;
            }
            catch (excecao.excecao ex)
            {
                throw new excecao.excecao(MSG_CHAVE_INVALIDA);
            }
            catch (NullReferenceException nu) 
            {
                throw new excecao.excecao(MSG_CHAVE_INVALIDA);
            }
        }
    
        // chave privada para assinar e texto 
        public static string assinaTexto(string caminhoChave, string texto)
        {
            try
            {
                AsymmetricCipherKeyPair parametrosChave = retornaParametrosChavePrivada(caminhoChave);

                RsaKeyParameters prikey = (RsaKeyParameters)parametrosChave.Private;

                var encoder = new ASCIIEncoding();
                var inputData = encoder.GetBytes(texto);

                var signer = SignerUtilities.GetSigner(MD5);
                signer.Init(true, prikey);
                signer.BlockUpdate(inputData, 0, inputData.Length);

                byte[] assinaturaByte = signer.GenerateSignature();
                string textoAssinado = Convert.ToBase64String(assinaturaByte);

                return textoAssinado;
            }
            catch (excecao.excecao ex)
            {
                throw new excecao.excecao(MSG_CHAVE_INVALIDA);
            }
        }

        // chave certificada e texto
        public static bool verificaAssinatura(string caminhoChave, string textoAssinado, string textoClaro)
        {
            try
            {
                AsymmetricKeyParameter parametrosCertificada = retornaParametrosCertificado(caminhoChave);
                byte[] assinaturaBytes = Convert.FromBase64String(textoAssinado);

                // conferir assinatura
                RsaKeyParameters pubkey = (RsaKeyParameters)parametrosCertificada;
                var encoder = new ASCIIEncoding();
                var inputData = encoder.GetBytes(textoClaro);
                var signer = SignerUtilities.GetSigner(MD5);
                signer.Init(false, pubkey);
                signer.BlockUpdate(inputData, 0, inputData.Length);
                bool assinaturaVerificada = signer.VerifySignature(assinaturaBytes);

                return assinaturaVerificada;
            }
            catch (excecao.excecao ex)
            {
                throw new excecao.excecao(MSG_CHAVE_INVALIDA);
            }
        }

        private static AsymmetricKeyParameter retornaParametrosCertificado(string caminhoCertificado)
        {
            try
            {
                X509Certificate2 chaveCertificada = new X509Certificate2(caminhoCertificado);
                X509CertificateParser parserChaveCertificada = new X509CertificateParser();
                AsymmetricKeyParameter parametrosCertificado = parserChaveCertificada.ReadCertificate(chaveCertificada.GetRawCertData()).GetPublicKey();

                return parametrosCertificado;
            }
            catch (Exception ex)
            {
                throw new excecao.excecao(MSG_CHAVE_INVALIDA);
            }
        }

        private static AsymmetricCipherKeyPair retornaParametrosChavePrivada(string caminhoChavePrivada)
        {
            try
            {
                StreamReader ChavePrivada = System.IO.File.OpenText(caminhoChavePrivada);
                PemReader pemChavePrivada = new PemReader(ChavePrivada);
                AsymmetricCipherKeyPair parametrosChave = (AsymmetricCipherKeyPair)pemChavePrivada.ReadObject();

                return parametrosChave;
            }
            catch (Exception ex)
            {
                throw new excecao.excecao(MSG_CHAVE_INVALIDA);
            }
        }
    
    }
}
