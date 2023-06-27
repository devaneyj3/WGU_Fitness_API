const express = require("express");

const routes = express.Router();
const mw = require("../middleware");
const endPoint = require("../endPoints");
const { CLIENTS, FITNESS_CLASSES } = require("../../contants");

routes.get("/", async (req, res) => {
	endPoint.getEndPoint(CLIENTS, res);
});
routes.post("/register", (req, res) => {
	endPoint.register(CLIENTS, req, res);
});
routes.post("/login", (req, res) => {
	endPoint.login(CLIENTS, req, res);
});

routes.get("/:id", (req, res) => {
	endPoint.findUser(CLIENTS, req, res);
});

//get individual clients classes
routes.get(`/:id/${FITNESS_CLASSES}`, (req, res) => {
	endPoint.getClassesByID(CLIENTS, req, res);
});

//CLIENT PICKS UP CLASSES THAT IS IN CLASSES DATABASE
routes.post(`/:id/${FITNESS_CLASSES}/:classID`, (req, res) => {
	endPoint.addClientClass(req, res);
});

routes.delete("/:id", mw.restrictedRoute, (req, res) => {
	endPoint.deleteData(CLIENTS, req, res);
});

routes.put("/:id", mw.missingProp, mw.restrictedRoute, (req, res) => {
	endPoint.editData(CLIENTS, req, res);
});

module.exports = routes;
