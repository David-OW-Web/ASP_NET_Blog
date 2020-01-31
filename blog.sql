-- phpMyAdmin SQL Dump
-- version 4.9.0.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Erstellungszeit: 31. Jan 2020 um 09:09
-- Server-Version: 10.3.16-MariaDB
-- PHP-Version: 7.1.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Datenbank: `blog`
--

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `account`
--

CREATE TABLE `account` (
  `account_id` int(11) NOT NULL,
  `username` varchar(30) DEFAULT NULL,
  `email` varchar(50) DEFAULT NULL,
  `password` varchar(255) DEFAULT NULL,
  `created_at` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Daten für Tabelle `account`
--

INSERT INTO `account` (`account_id`, `username`, `email`, `password`, `created_at`) VALUES
(1, 'Admin', 'david.peric@kauz.ch', 'david', '2020-01-29 15:13:11'),
(2, 'xxEpic', 'epic2003@gmx.ch', 'epicXD', '2020-01-29 15:13:11'),
(3, 'Admin1', 'david@kauz.cc', 'david', '2020-01-29 15:13:11'),
(4, 'DavidPeric', 'peric@kauz.ch', 'david', '2020-01-30 15:50:30');

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `comment`
--

CREATE TABLE `comment` (
  `comment_id` int(11) NOT NULL,
  `title` varchar(30) DEFAULT NULL,
  `body` varchar(100) DEFAULT NULL,
  `comment_date` datetime DEFAULT current_timestamp(),
  `fk_post_id` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Daten für Tabelle `comment`
--

INSERT INTO `comment` (`comment_id`, `title`, `body`, `comment_date`, `fk_post_id`) VALUES
(1, 'Test comment', 'Does comment work? o_O', '2020-01-30 08:34:09', 20),
(2, 'Test 2', 'Commen test #2', '2020-01-30 08:36:43', 20),
(3, 'Test#3', 'Comment#3', '2020-01-30 08:38:06', 20),
(5, 'Thanks', 'Thanks for post!', '2020-01-30 08:41:43', 17);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `post`
--

CREATE TABLE `post` (
  `post_id` int(11) NOT NULL,
  `title` varchar(100) DEFAULT NULL,
  `body` text DEFAULT NULL,
  `created_at` datetime DEFAULT current_timestamp(),
  `updated_at` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Daten für Tabelle `post`
--

INSERT INTO `post` (`post_id`, `title`, `body`, `created_at`, `updated_at`) VALUES
(1, 'ASP.NET Mysql', 'ASP.NET Core MVC with MySQL database', '2020-01-28 12:48:33', '2020-01-28 12:48:33'),
(2, 'PHP MVC', 'PHP MVC Mysql', '2020-01-28 12:48:33', '2020-01-28 12:48:33'),
(3, 'ASP.NET Mysql', 'ASP.NET Core MVC with MySQL database', '2020-01-28 12:48:33', '2020-01-28 12:48:33'),
(4, 'PHP MVC', 'PHP MVC Mysql', '2020-01-28 12:48:33', '2020-01-28 12:48:33'),
(5, 'ASP.NET Mysql', 'ASP.NET Core MVC with MySQL database', '2020-01-28 12:48:33', '2020-01-28 12:48:33'),
(6, 'PHP MVC', 'PHP MVC Mysql', '2020-01-28 12:48:33', '2020-01-28 12:48:33'),
(7, 'ASP.NET Mysql', 'ASP.NET Core MVC with MySQL database', '2020-01-28 12:48:33', '2020-01-28 12:48:33'),
(8, 'PHP MVC', 'PHP MVC Mysql', '2020-01-28 12:48:33', '2020-01-28 12:48:33'),
(9, 'ASP.NET Mysql', 'ASP.NET Core MVC with MySQL database', '2020-01-28 12:48:33', '2020-01-28 12:48:33'),
(10, 'PHP MVC', 'PHP MVC Mysql', '2020-01-28 12:48:33', '2020-01-28 12:48:33'),
(11, 'ASP.NET Mysql', 'ASP.NET Core MVC with MySQL database', '2020-01-28 12:48:33', '2020-01-28 12:48:33'),
(16, 'Another session test', 'XDD asp.net sessions XD', '2020-01-28 13:30:12', '2020-01-28 13:30:12'),
(17, 'SessionTest2', 'Another TEST XD', '2020-01-28 13:30:33', '2020-01-28 13:30:33'),
(20, 'Controller:PostAction:Create', 'Test if edit works #2', '2020-01-29 11:36:11', '2020-01-29 12:54:35'),
(21, 'No', 'It', '2020-01-30 10:21:56', '2020-01-30 10:21:56'),
(22, 'Test', 'Test if validation works', '2020-01-30 10:24:28', '2020-01-30 10:24:28'),
(24, 'Test', 'Does it work?', '2020-01-30 10:28:56', '2020-01-30 10:28:56'),
(25, 'Yes', 'It does', '2020-01-30 10:29:11', '2020-01-30 10:29:11'),
(26, 'Post title', 'New post', '2020-01-30 10:29:18', '2020-01-30 10:29:18');

--
-- Indizes der exportierten Tabellen
--

--
-- Indizes für die Tabelle `account`
--
ALTER TABLE `account`
  ADD PRIMARY KEY (`account_id`);

--
-- Indizes für die Tabelle `comment`
--
ALTER TABLE `comment`
  ADD PRIMARY KEY (`comment_id`),
  ADD KEY `fk_post_id` (`fk_post_id`);

--
-- Indizes für die Tabelle `post`
--
ALTER TABLE `post`
  ADD PRIMARY KEY (`post_id`);

--
-- AUTO_INCREMENT für exportierte Tabellen
--

--
-- AUTO_INCREMENT für Tabelle `account`
--
ALTER TABLE `account`
  MODIFY `account_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT für Tabelle `comment`
--
ALTER TABLE `comment`
  MODIFY `comment_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT für Tabelle `post`
--
ALTER TABLE `post`
  MODIFY `post_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=27;

--
-- Constraints der exportierten Tabellen
--

--
-- Constraints der Tabelle `comment`
--
ALTER TABLE `comment`
  ADD CONSTRAINT `comment_ibfk_1` FOREIGN KEY (`fk_post_id`) REFERENCES `post` (`post_id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
