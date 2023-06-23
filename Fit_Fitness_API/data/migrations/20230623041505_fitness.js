exports.up = function (knex) {
	return knex.schema
		.createTable("clients", (tbl) => {
			tbl.increments();
			tbl.text("name").notNullable();
			tbl.text("email").notNullable();
			tbl.text("phone").notNullable();
			tbl.text("username").notNullable();
			tbl.text("password").notNullable();
		})
		.createTable("instructors", (tbl) => {
			tbl.increments();
			tbl.text("name").notNullable();
			tbl.text("email").notNullable();
			tbl.text("phone").notNullable();
			tbl.text("username").notNullable();
			tbl.text("password").notNullable();
		})
		.createTable("fitness_classes", (tbl) => {
			tbl.increments();
			tbl.text("name").notNullable();
			tbl.text("location").notNullable();
			tbl.text("details").notNullable();
			tbl.text("instructorname").notNullable();
			tbl.text("instructoremail").notNullable();
			tbl.text("instructorphone").notNullable();
			tbl.timestamp("start_time").notNullable();
			tbl.timestamp("end_time").notNullable();
			tbl.integer("enrollment").notNullable();
			tbl.integer("capacity").notNullable().unsigned();
			tbl.text("type");
			tbl
				.integer("instructor_id")
				.unsigned()
				.notNullable()
				.references("id")
				.inTable("instructors")
				.onUpdate("CASCADE")
				.onDelete("CASCADE");
		})
		.createTable("clients_classes", (tbl) => {
			tbl
				.integer("class_id")
				.notNullable()
				.unsigned()
				.references("id")
				.inTable("fitness_classes")
				.onUpdate("CASCADE")
				.onDelete("CASCADE");
			tbl
				.integer("client_id")
				.notNullable()
				.unsigned()
				.references("id")
				.inTable("clients")
				.onUpdate("CASCADE")
				.onDelete("CASCADE");
			tbl.primary(["class_id", "client_id"]);
		});
};

exports.down = function (knex) {
	return knex.schema
		.dropTableIfExist("clients_classes")
		.dropTableIfExist("fitness_classes")
		.dropTableIfExist("instructors")
		.dropTableIfExist("clients");
};
