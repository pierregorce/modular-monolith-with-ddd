namespace Bazimo.Core.SharedKernel.Common.Results
{
    public static class Errors
    {
        public static string ShouldBeNull(string argument) { return $"{argument} ShouldBeNull"; }
        public static string ShouldNotBeNull(string argument) { return $"{argument} ShouldNotBeNull"; }
        public static string ShouldHaveMaxLength(string argument, int maxLength) { return $"{argument} ShouldHaveMaxLength Of ({maxLength})"; }
        public static string ShouldBeInEnum(string argument) { return $"{argument} ShouldBeInEnum"; }
        public static string ShouldBeStrictlyPositive(string argument) { return $"{argument} ShouldBeStrictlyPositive"; }
        public static string ShouldBePositiveOrEqualToZero(string argument) { return $"{argument} ShouldBePositiveOrEqualToZero"; }
        public static string ShouldBeGreaterThan(string argument, int value) { return $"{argument} ShouldBeGreaterThan {value})"; }
        public static string ShouldNotAlreadyExist(string argument) { return $"{argument} ShouldNotAlreadyExist)"; }
        public static string ShouldExist(string argument) { return $"{argument} ShouldExist"; }
        public static string CantHydrateAggregate(string argument) { return $"{argument} CantHydrateAggregate"; }
        public static string ItemsAreNotAllowedToRequest(string argument) { return $"{argument} ItemsAreNotAllowedToRequest"; }
        public static string NotFoundWithArgument(string argument) { return $"NotFoundWithArgument {argument}"; }
        public static string DataOriginDoNotMatchWithUseCase() { return $"DataOriginDoNotMatchWithUseCase"; }

        // Accesses

        public static string SessionIsRequired() { return $"SessionIsRequired"; }
        public static string UserMustHaveRole(string argument) { return $"UserMustHaveRole {argument}"; }
        public static string UserMustBeBazimoAgent() { return $"UserMustBeBazimoAgent"; }

    }
}