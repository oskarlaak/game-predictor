module.exports = {
    env: {
        node: true,
        browser: true,
        es2020: true
    },
    extends: [
        "eslint:recommended",
        "plugin:@typescript-eslint/recommended",
        "plugin:react-hooks/recommended"
    ],
    parser: "@typescript-eslint/parser",
    parserOptions: {
        ecmaVersion: "latest",
        sourceType: "module"
    },
    plugins: [
        "react-refresh",
        "@typescript-eslint"
    ],
    rules: {
        "react-refresh/only-export-components": "warn",

        "require-await": "error",                                       // require await
        "quotes": ["error", "double"],                                  // "" instead of ''
        "eol-last": ["error", "always"],                                // newline at end
        "comma-dangle": ["error", "never"],                             // no trailing commas

        "@typescript-eslint/semi": ["error", "always"],                 // require ;
        "@typescript-eslint/explicit-member-accessibility": "error",    // public / protected / private
        "@typescript-eslint/explicit-function-return-type": ["error", { // function return types
            allowExpressions: true
        }],
        "@typescript-eslint/member-delimiter-style": ["error", {        // properties end with ;
            multiline: {
                delimiter: "semi",
                requireLast: true
            },
            singleline: {
                delimiter: "semi",
                requireLast: true
            }
        }]
    }
};
