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

//remove classes from client on withdraw
routes.delete(`/:id/${FITNESS_CLASSES}/:classID/remove`, (req, res) => {
	endPoint.removeClientClass(req, res);
});

routes.delete("/:id", (req, res) => {
	endPoint.deleteData(CLIENTS, req, res);
});

routes.put("/:id", mw.missingProp, (req, res) => {
	endPoint.editData(CLIENTS, req, res);
});

module.exports = routes;
