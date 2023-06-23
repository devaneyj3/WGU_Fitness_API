const express = require('express');

const routes = express.Router();
const mw = require('../middleware');
const endPoint = require('../endPoints');

routes.get('/', async (req, res) => {
    endPoint.getEndPoint('clients', res)
})
routes.post('/register', mw.missingProp, (req, res) => {
    endPoint.register('clients', res, req)
})
routes.post('/login', mw.missingProp, (req, res) => {
    endPoint.login('clients', req, res)
})


routes.get('/:id', mw.restrictedRoute, (req, res) => {
    endPoint.findUser('clients', req, res)
})

//get individual clients classes
routes.get('/:id/classes', mw.restrictedRoute, (req, res) => {
    endPoint.getClassesByID('clients', req, res)
})

//CLIENT PICKS UP CLASSES THAT IS IN CLASSES DATABASE
routes.post('/:id/classes/:classID', mw.restrictedRoute, (req, res) => {
    endPoint.addClientClass(req, res)
})


routes.delete('/:id', mw.restrictedRoute, (req, res) => {
    endPoint.deleteData('clients', req, res)
})

routes.put('/:id', mw.missingProp, mw.restrictedRoute, (req, res) => {
    endPoint.editData('clients', req, res)
})

module.exports = routes;