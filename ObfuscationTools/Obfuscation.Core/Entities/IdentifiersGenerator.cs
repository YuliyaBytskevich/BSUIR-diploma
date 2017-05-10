namespace Obfuscation.Core.Entities
{
    public static class IdentifiersGenerator
    {
        private static string basis;
        private static int startNumber = 0;
        private static int currentNumber;
        
        public static void SetGenerator(string basis, int startNumber)
        {
            IdentifiersGenerator.basis = basis;
            IdentifiersGenerator.startNumber = startNumber;
            IdentifiersGenerator.currentNumber = startNumber;
        }

        public static void ResetGenerator()
        {
            currentNumber = startNumber;
        }

        public static string Generate()
        {
            if (currentNumber == int.MaxValue)
            {
                basis += '_';
            }

            return basis + (currentNumber++);
        }
    }
}
