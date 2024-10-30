namespace Dobra.Validators;

public static class CnpjValidator {
    public static bool Validate(ReadOnlySpan<char> cnpj) {
        if (cnpj == null || cnpj.Length != 14) {
            return false;
        }

        unsafe {
            fixed (char* ptr = cnpj) {
                for (int i = 0; i != 14; i += 1) {
                    var c = *(ptr + i);
                    if (c < '0' || c > '9') {
                        return false;
                    }
                }

                int sum1 = 0, sum2 = 0;
                int digit;
                for (int i = 0; i != 4; i += 1) {
                    digit = *(ptr + i) - '0';
                    sum1 += digit * (5 - i);
                    sum2 += digit * (6 - i);
                }
                digit = *(ptr + 4) - '0';
                sum1 += digit * 9;
                sum2 += digit * 2;
                for (int i = 5; i != 12; i += 1) {
                    digit = *(ptr + i) - '0';
                    sum1 += digit * (13 - i);
                    sum2 += digit * (14 - i);
                }

                int digito1 = sum1 % 11;
                if (digito1 == 1) { digito1 = 0; } else { digito1 = 11 - digito1; }

                sum2 += digito1 * 2;

                int digito2 = sum2 % 11;
                if (digito2 == 1) { digito2 = 0; } else { digito2 = 11 - digito2; }

                return digito1 == *(ptr + 12) - '0' && digito2 == *(ptr + 13) - '0';
            }
        }
    }
}
