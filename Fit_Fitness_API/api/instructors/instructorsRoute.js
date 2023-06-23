const express = require('express');

const routes = express.Router();
const mw = require('../middleware');
const endPoint = require('../endPoints');

routes.get('/', (req, res) => {
    endPoint.getEndPoint('instructors', res)
})
routes.post('/register', mw.missingProp, async (req, res) => {
    endPoint.register('instructors', res, req)
})
routes.post('/login', mw.missingProp, async (req, res) => {
    endPoint.login('instructors', req, res)

});

// get individual instructors AND AUTHETICATE
routes.get('/:id',  mw.restrictedRoute, (req, res) => {
    endPoint.findUser('instructors', req, res)
})

//get individual instructors classes AND AUTHETICATE
routes.get('/:id/classes', mw.restrictedRoute, (req, res) => {
    endPoint.getClassesByID('instructors', req, res)
})

//INSTRUCTOR CAN POST CLASSES THAT THEY TEACH AUTHENTICATE
// TODO: THIS IS NOT POSTING IN PRODUCTION
routes.post('/:id/classes', mw.missingClassProps, mw.restrictedRoute, async (req, res) => {
    endPoint.instructorsNewClasses('classes', req, res)

});


routes.delete('/:id', mw.restrictedRoute, (req, res) => { 
    endPoint.deleteData('instructors', req, res)
})

routes.put('/:id', mw.missingProp, mw.restrictedRoute, (req, res) => {
    endPoint.editData('instructors', req, res)
})

module.exports = routes;