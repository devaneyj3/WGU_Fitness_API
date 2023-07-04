module.exports = {
	development: {
		client: "pg",
		debug: true,
		connection: {
			host: process.env.HOST,
			port: process.env.DB_PORT,
			database: "fit_fitness",
			user: process.env.USER,
			password: process.env.PASSWORD,
		},
		migrations: {
			directory: "./data/migrations",
		},
		ssl: {
			rejectUnauthorized: false,
		},
		useNullAsDefault: true,
	},

	production: {
		client: "postgresql",
		debug: true,
		connection: {
			connectionString: process.env.DATABASE_URL,
			ssl: {
				rejectUnauthorized: false,
			},
		},
		migrations: {
			directory: "./data/migrations",
		},
	},
};
