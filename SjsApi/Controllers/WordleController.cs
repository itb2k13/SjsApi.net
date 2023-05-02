namespace SjsApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="WordleController" />.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class WordleController : ControllerBase
    {
        /// <summary>
        /// Defines the _logger.
        /// </summary>
        private readonly ILogger<WordleController> _logger;

        /// <summary>
        /// Keeps a copy of the Wordles.
        /// </summary>
        private static List<string> _wordles = new List<string>();

        /// <summary>
        /// Keeps a timestamp of when the wordle data was last retrieved.
        /// </summary>
        private static DateTime _lastRetrieved = DateTime.MinValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="WordleController"/> class.
        /// </summary>
        /// <param name="logger">The logger<see cref="ILogger{WordleController}"/>.</param>
        public WordleController(ILogger<WordleController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// The Get.
        /// </summary>
        /// <param name="url">The url<see cref="string"/>.</param>
        /// <returns>The <see cref="List{string}"/>.</returns>
        [HttpGet]
        public async Task<List<string>> Get()
        {
            using (var httpClient = new HttpClient())
            {
                if (_wordles.Count > 0 && (DateTime.Now - _lastRetrieved).TotalMinutes <= (12 * 60))
                    return _wordles;

                var response = await httpClient.GetStringAsync("https://www.rockpapershotgun.com/wordle-past-answers");

                _wordles = Regex
                    .Matches(response, @"(?<=<li>)(.*?)(?=<\/li>)")
                    .Cast<Match>()
                    .Select(p => p.Value)
                    .Where(x => !string.IsNullOrEmpty(x) && x.Length == 5)
                    .ToList();

                _lastRetrieved = DateTime.Now;

                return _wordles;
            }
        }
    }
}
