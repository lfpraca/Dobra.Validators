namespace Dobra.Validators;

public static class CpfValidator {
    public static bool Validate(ReadOnlySpan<char> cpf) {
        if (cpf == null || cpf.Length != 11) {
            return false;
        }

        unsafe {
            fixed (char* ptr = cpf) {
                for (int i = 0; i != 11; i += 1) {
                    var c = *(ptr + i);
                    if (c < '0' || c > '9') {
                        return false;
                    }
                }

                var allEq = true;
                for (int i = 1; i != 11; i += 1) {
                    if (*(ptr + i) != *ptr) {
                        allEq = false;
                        break;
                    }
                }
                if (allEq) {
                    return false;
                }

                int sum1 = 0, sum2 = 0;
                for (int i = 0; i != 9; i += 1) {
                    int digit = *(ptr + i) - '0';
                    sum1 += digit * (i + 1);
                    sum2 += digit * i;
                }

                int digito1 = sum1 % 11;
                if (digito1 == 10) { digito1 = 0; }
                sum2 += digito1 * 9;

                int digito2 = sum2 % 11;
                if (digito2 == 10) { digito2 = 0; }

                return digito1 == *(ptr + 9) - '0' && digito2 == *(ptr + 10) - '0';
            }
        }
    }
}
