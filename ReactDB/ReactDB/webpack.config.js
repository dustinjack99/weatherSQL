const path = require("path");

module.exports = {
    context: __dirname,
    entry: "./Scripts/React/src/",
    output: {
        path: path.resolve(__dirname, "wwwroot"),
        filename: "bundle.js",
    },
    resolve: {
        extensions: [".js", ".jsx"]
    },
    watch: true,
    module: {
        rules: [{
            test: /\.(js|jsx)$/,
            exclude: /(node_modules)/,
            use: {
                loader: 'babel-loader',
                options: {
                    presets: ['@babel/preset-env', '@babel/preset-react']
                }
            }
        }]
    }
} 