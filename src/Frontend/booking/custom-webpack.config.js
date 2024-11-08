const { EnvironmentPlugin, DefinePlugin } = require('webpack');


module.exports = {
  plugins: [

    new DefinePlugin({
      'process.env': JSON.stringify(process.env) // This exposes the process.env to the browser
    })
  ]
};
