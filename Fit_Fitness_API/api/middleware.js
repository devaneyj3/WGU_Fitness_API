const jwt = require('jsonwebtoken');
const secrets = require('./config');

module.exports = {
    missingProp,
    restrictedRoute,
    missingClassProps
}

function missingProp(req, res, next) {
    if (req.body.username === "" || req.body.password === "") {
        return res.status(404).json({ message: 'You can\'t submit empty name or password fields' })
    } else if (!req.body.hasOwnProperty('username') || !req.body.hasOwnProperty('password')) {
        return res.status(400).json({ message: 'You are missing a username or a password property' })
    }
    else {
        next()
    }
}
function missingClassProps(req, res, next) {
    if (req.body.name === "" || req.body.type === "" || req.body.startTime === "" || req.body.duration === "" || req.body.intensityLevel === "" || req.body.location === "" || req.body.attendees === "" || req.body.maxClassSize === "") {
        return res.status(404).json({ message: 'You can\'t submit empty name, type, startTime, duration, intensityLevel, location, attendees, and maxClassSize fields' })
    } else if (!req.body.hasOwnProperty('name') || !req.body.hasOwnProperty('type') || !req.body.hasOwnProperty('startTime') || !req.body.hasOwnProperty('duration') || !req.body.hasOwnProperty('intensityLevel') || !req.body.hasOwnProperty('location') || !req.body.hasOwnProperty('attendees') || !req.body.hasOwnProperty('maxClassSize')) {
        return res.status(400).json({ message: ' You are missing name, type, startTime, duration, intensityLevel, location, attendees, and maxClassSize fields' })
    }
    else {
        next()
    }
}

function restrictedRoute(req, res, next) {
    const token = req.headers.authorization;
    if (token) {
        jwt.verify(token, secrets.jwtSecret, (err, decodedToken) => {
            if (err) {
                return res.status(401).json({ message: "You are not authorized to enter" })
            } else {
                res.decodedToken = decodedToken
                res.role = decodedToken.role;
                next();
            }
        })
    } else {
        return res.status(401).json({ message: "You are not authorized to enter" })
    }
}