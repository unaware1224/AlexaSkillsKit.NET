using AlexaSkillsKit.Authentication;
using NUnit.Framework;

namespace AlexaSkillsKit.Tests
{
    /// <summary>
    ///     Test certification validations.
    /// </summary>
    [TestFixture]
    public class CertificationTests
    {
        /// <summary>
        ///     Tests that the URL validation passes all of Amazon's test cases.
        /// </summary>
        /// <param name="urlToValidate">The URL to validate.</param>
        /// <param name="isValid">Whether or not the URL is valid.</param>
        /// <param name="reason">The reason the URL is valid or not.</param>
        [TestCase("https://s3.amazonaws.com/echo.api/echo-api-cert.pem", true, "Valid")]
        [TestCase("https://s3.amazonaws.com:443/echo.api/echo-api-cert.pem", true, "Valid with port")]
        [TestCase("https://s3.amazonaws.com/echo.api/../echo.api/echo-api-cert.pem", true, "Valid long path")]
        [TestCase("http://s3.amazonaws.com/echo.api/echo-api-cert.pem", false, "Invalid port")]
        [TestCase("https://notamazon.com/echo.api/echo-api-cert.pem", false, "Invalid host")]
        [TestCase("https://s3.amazonaws.com/EcHo.aPi/echo-api-cert.pem", false, "Invalid path casing")]
        [TestCase("https://s3.amazonaws.com/invalid.path/echo-api-cert.pem", false, "Invalid path")]
        [TestCase("https://s3.amazonaws.com:563/echo.api/echo-api-cert.pem", false, "Invalid port")]
        [Test]
        public void VerifyUrl(
            string urlToValidate,
            bool isValid,
            string reason)
        {
            Assert.IsTrue(
                          SpeechletRequestSignatureVerifier.IsValidUrl(urlToValidate) == isValid,
                          reason);
        }
    }
}