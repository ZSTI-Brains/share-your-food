-- phpMyAdmin SQL Dump
-- version 4.7.5
-- https://www.phpmyadmin.net/
--
-- Host: localhost
-- Generation Time: Oct 25, 2019 at 11:50 PM
-- Server version: 10.1.41-MariaDB-cll-lve
-- PHP Version: 5.6.40

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `szaryweb1_share-your-food`
--

-- --------------------------------------------------------

--
-- Table structure for table `eating_houses`
--

CREATE TABLE `eating_houses` (
  `house_id` int(11) NOT NULL,
  `name` varchar(64) NOT NULL,
  `owner_first_name` varchar(32) NOT NULL,
  `owner_last_name` varchar(32) NOT NULL,
  `street_name` varchar(64) NOT NULL,
  `house_number` varchar(8) NOT NULL,
  `apartament_number` varchar(8) DEFAULT NULL,
  `postal_code` varchar(6) NOT NULL,
  `city_name` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `eating_houses`
--

INSERT INTO `eating_houses` (`house_id`, `name`, `owner_first_name`, `owner_last_name`, `street_name`, `house_number`, `apartament_number`, `postal_code`, `city_name`) VALUES
(1, 'Puchatek', 'Janusz', 'Pasieka', 'Słomka', '133', NULL, '34-730', 'Mszana Dolna'),
(2, 'Różowy Talerz', 'Jakub', 'Kowalski', 'św. Maksymiliana Marii Kolbego', '50', NULL, '34-730', 'Mszana Dolna'),
(3, 'Gorący Kubek', 'Weronika', 'Rabarbarska', 'Krakowska', '61', NULL, '34-730', 'Mszana Dolna');

-- --------------------------------------------------------

--
-- Table structure for table `eating_house_coordinates`
--

CREATE TABLE `eating_house_coordinates` (
  `house_id` int(11) NOT NULL,
  `latitude` decimal(9,6) NOT NULL,
  `longitude` decimal(9,6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `eating_house_coordinates`
--

INSERT INTO `eating_house_coordinates` (`house_id`, `latitude`, `longitude`) VALUES
(1, 49.694100, 20.119400),
(2, 49.675290, 20.068074),
(3, 49.686539, 20.049186);

-- --------------------------------------------------------

--
-- Table structure for table `product_offerors`
--

CREATE TABLE `product_offerors` (
  `offeror_id` int(11) NOT NULL,
  `name` varchar(128) NOT NULL,
  `website` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `product_offerors`
--

INSERT INTO `product_offerors` (`offeror_id`, `name`, `website`) VALUES
(1, 'Tesco', 'https://tesco.pl/'),
(2, 'Żabka', 'https://www.zabka.pl/'),
(3, 'Lewiatan', 'https://lewiatan.pl/');

-- --------------------------------------------------------

--
-- Table structure for table `product_offers`
--

CREATE TABLE `product_offers` (
  `offer_id` int(11) NOT NULL,
  `offeror_id` int(11) NOT NULL,
  `name` varchar(128) NOT NULL,
  `discount` decimal(10,2) NOT NULL,
  `code` varchar(128) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `product_offers`
--

INSERT INTO `product_offers` (`offer_id`, `offeror_id`, `name`, `discount`, `code`) VALUES
(1, 1, 'Bon rabatowy na 20 zł', 20.00, 'TESCO-2000-ABCD0001'),
(2, 1, 'Bon rabatowy na 20 zł', 20.00, 'TESCO-2000-ABCD0002'),
(3, 1, 'Bon rabatowy na 20 zł', 20.00, 'TESCO-2000-ABCD0003'),
(4, 1, 'Bon rabatowy na 10 zł', 10.00, 'TESCO-1000-ABCD0001'),
(5, 1, 'Bon rabatowy na 10 zł', 10.00, 'TESCO-1000-ABCD0002'),
(6, 2, 'Bon rabatowy 10 zł', 10.00, 'ZABKA-1000-ABCD0001');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `user_id` int(11) NOT NULL,
  `first_name` varchar(32) NOT NULL,
  `last_name` varchar(32) NOT NULL,
  `password` varchar(256) NOT NULL,
  `email` varchar(256) NOT NULL,
  `points` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`user_id`, `first_name`, `last_name`, `password`, `email`, `points`) VALUES
(1, 'Marcin', 'Gortat', '$2y$10$nuUMGLra5tFca2aKKfMhT.AjngeQVXcjWIYHAD.c2JTF.ZUNtkUnm', 'marcin.gortat@nba.com', 0),
(2, 'Sebastian', 'Wokulski', '$2y$10$Y0xfy/DH/8BmFcbKa1IqBeJ8lQO0kT1EN4OoEl2WahCuzPSKCs05K', 's.wokulski@gmail.com', 256),
(3, 'Sebastian', 'Wokulski', '$2y$10$Pn74MzbzNxc4S/L3y8oCieRdq6Sp8C/qSK12GC/AgXP.rqDDxHi6e', 'swokulski@gmail.com', 0),
(4, 'Jakub', 'Kowalski', '$2y$10$qiuAU8jQbyrv0kKs5ay1zebL5XH9ujDOwIFG8PHustZ5FtgNh3Zm.', 'jakub.kowalski@onet.pl', 0);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `eating_houses`
--
ALTER TABLE `eating_houses`
  ADD PRIMARY KEY (`house_id`),
  ADD UNIQUE KEY `ideating_house_UNIQUE` (`house_id`);

--
-- Indexes for table `eating_house_coordinates`
--
ALTER TABLE `eating_house_coordinates`
  ADD PRIMARY KEY (`house_id`),
  ADD KEY `fk_eating_house_coordinates_eating_houses_idx` (`house_id`);

--
-- Indexes for table `product_offerors`
--
ALTER TABLE `product_offerors`
  ADD PRIMARY KEY (`offeror_id`),
  ADD UNIQUE KEY `offeror_id` (`offeror_id`);

--
-- Indexes for table `product_offers`
--
ALTER TABLE `product_offers`
  ADD PRIMARY KEY (`offer_id`),
  ADD UNIQUE KEY `offer_id` (`offer_id`),
  ADD KEY `offeror_id` (`offeror_id`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`user_id`),
  ADD UNIQUE KEY `user_id_UNIQUE` (`user_id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `eating_houses`
--
ALTER TABLE `eating_houses`
  MODIFY `house_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `product_offerors`
--
ALTER TABLE `product_offerors`
  MODIFY `offeror_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `product_offers`
--
ALTER TABLE `product_offers`
  MODIFY `offer_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `user_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `eating_house_coordinates`
--
ALTER TABLE `eating_house_coordinates`
  ADD CONSTRAINT `fk_eating_house_coordinates_eating_houses` FOREIGN KEY (`house_id`) REFERENCES `eating_houses` (`house_id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `product_offers`
--
ALTER TABLE `product_offers`
  ADD CONSTRAINT `product_offers_ibfk_1` FOREIGN KEY (`offeror_id`) REFERENCES `product_offerors` (`offeror_id`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
