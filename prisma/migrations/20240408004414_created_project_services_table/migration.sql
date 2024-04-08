-- CreateTable
CREATE TABLE `project_services` (
    `id` INTEGER NOT NULL AUTO_INCREMENT,
    `project_id` INTEGER NOT NULL,
    `service_id` INTEGER NOT NULL,

    UNIQUE INDEX `project_services_service_id_key`(`service_id`),
    PRIMARY KEY (`id`)
) DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
