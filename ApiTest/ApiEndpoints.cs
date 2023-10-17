namespace ApiTest;

/// <summary>
/// This is to reduce the likelihood of introducing errors related to controller routing
/// </summary>
public static class ApiEndpoints
{
    private const string ApiBase = "api";
    
    public static class People
    {
        private const string Base = $"{ApiBase}/people";

        public const string Create = Base;
        public const string Get = $"{Base}/{{id:long}}";
        public const string GetAll = $"{Base}";
        public const string Update = $"{Base}";
        public const string Delete = $"{Base}/{{id:long}}";
    }
}