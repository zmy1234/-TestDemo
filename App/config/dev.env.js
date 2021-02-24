'use strict'
const merge = require('webpack-merge')
const prodEnv = require('./prod.env')

module.exports = merge(prodEnv, {
  BEST_URL:'"/api"',
  NODE_ENV: '"development"'
})


