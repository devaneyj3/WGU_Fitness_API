const { FITNESS_CLASSES, INSTRUCTORS } = require("../../contants");
const express = require("express");

const routes = express.Router();
const mw = require("../middleware");
const endPoint = require("../endPoints");

routes.get("/", (req, res) => {
	endPoint.getEndPoint(INSTRUCTORS, res);
});
routes.post("/register", mw.missingProp, async (req, res) => {
	endPoint.register(INSTRUCTORS, req, res);
});
routes.post("/login", mw.missingProp, async (req, res) => {
	endPoint.login(INSTRUCTORS, req, res);
});

// get individual instructors AND AUTHETICATE
routes.get("/:id", mw.restrictedRoute, (req, res) => {
	endPoint.findUser(INSTRUCTORS, req, res);
});

//get individual instructors classes AND AUTHETICATE
routes.get("/:id/fitness_classes", (req, res) => {
	endPoint.getClassesByID(INSTRUCTORS, req, res);
});

//INSTRUCTOR CAN POST CLASSES THAT THEY TEACH AUTHENTICATE
// TODO: THIS IS NOT POSTING IN PRODUCTION
routes.post("/:id/fitness_classes", async (req, res) => {
	endPoint.instructorsNewClasses(FITNESS_CLASSES, req, res);
});

routes.delete("/:id", (req, res) => {
	endPoint.deleteData(INSTRUCTORS, req, res);
});

routes.put("/:id", mw.missingProp, mw.restrictedRoute, (req, res) => {
	endPoint.editData(INSTRUCTORS, req, res);
});

module.exports = routes;
