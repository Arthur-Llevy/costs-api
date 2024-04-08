import { FastifyInstance } from 'fastify';
import { prisma } from '../lib/prisma';
import { ZodTypeProvider } from 'fastify-type-provider-zod';

export async function getAllEvents(app: FastifyInstance) {
	app.
	withTypeProvider<ZodTypeProvider>()
	.get('/projects', async (request, reply) => {
		
	})
}