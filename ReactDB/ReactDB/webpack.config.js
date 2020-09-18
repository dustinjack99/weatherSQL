module.exports = {
    context: __dirname,
    entry: "./Scripts/React/src/tutorial.jsx",
    output: {
        path: "./wwwroot/js",
        filename: "bundle.js",
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