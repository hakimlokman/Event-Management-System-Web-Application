﻿// <auto-generated />
using System;
using Event_Management_System.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Event_Management_System.Migrations
{
    [DbContext(typeof(EventDbContext))]
    [Migration("20240425084749_venuephoto")]
    partial class venuephoto
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Event_Management.Models.Allowcation", b =>
                {
                    b.Property<int>("AllowcationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AllowcationId"));

                    b.Property<int>("CustomerBookingId")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int?>("WorkerId")
                        .HasColumnType("int");

                    b.HasKey("AllowcationId");

                    b.HasIndex("CustomerBookingId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("WorkerId");

                    b.ToTable("Allowcations");
                });

            modelBuilder.Entity("Event_Management.Models.CustomerBooking", b =>
                {
                    b.Property<int>("CustomerBookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerBookingId"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int?>("CustomerRegistrationCustomerId")
                        .HasColumnType("int");

                    b.Property<int?>("EquipmentId")
                        .HasColumnType("int");

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<int?>("FoodId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FromDateOfEvent")
                        .HasColumnType("date");

                    b.Property<int>("NumberOfGuest")
                        .HasColumnType("int");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ServicesId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ToDateOfEvent")
                        .HasColumnType("date");

                    b.Property<int>("VenueId")
                        .HasColumnType("int");

                    b.HasKey("CustomerBookingId");

                    b.HasIndex("CustomerRegistrationCustomerId");

                    b.HasIndex("EquipmentId");

                    b.HasIndex("EventId");

                    b.HasIndex("FoodId");

                    b.HasIndex("ServicesId");

                    b.HasIndex("VenueId");

                    b.ToTable("CustomerBookings");
                });

            modelBuilder.Entity("Event_Management.Models.CustomerRegistration", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("date");

                    b.HasKey("CustomerId");

                    b.ToTable("CustomerRegistrations");
                });

            modelBuilder.Entity("Event_Management.Models.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartmentId"));

                    b.Property<string>("DepartmentDescription")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("DepartmentHead")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("DepartmentId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Event_Management.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Designation")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("EmployeeName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("JoinDate")
                        .HasColumnType("date");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("EmployeeId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Event_Management.Models.Event", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EventId"));

                    b.Property<string>("EventName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("EventId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("Event_Management.Models.Feedback", b =>
                {
                    b.Property<int>("FeedbackId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FeedbackId"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("FeedbackDate")
                        .HasColumnType("date");

                    b.HasKey("FeedbackId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("Event_Management.Models.Food", b =>
                {
                    b.Property<int>("FoodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FoodId"));

                    b.Property<string>("FoodName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("FoodTypeId")
                        .HasColumnType("int");

                    b.Property<decimal>("UnitCost")
                        .HasColumnType("money");

                    b.HasKey("FoodId");

                    b.HasIndex("FoodTypeId");

                    b.ToTable("Foods");
                });

            modelBuilder.Entity("Event_Management.Models.LogIn", b =>
                {
                    b.Property<int>("LogInId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LogInId"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastLogin")
                        .HasColumnType("date");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("LogInId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("LogIns");
                });

            modelBuilder.Entity("Event_Management.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<DateTime>("DeliveryDate")
                        .HasColumnType("date");

                    b.Property<string>("EquipmentName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("date");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalCost")
                        .HasColumnType("money");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("money");

                    b.HasKey("OrderId");

                    b.HasIndex("SupplierId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Event_Management.Models.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentId"));

                    b.Property<decimal>("AdvancePayment")
                        .HasColumnType("money");

                    b.Property<decimal>("AmountToBePaid")
                        .HasColumnType("money");

                    b.Property<int>("CustomerBookingId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("date");

                    b.Property<decimal>("RemainingAmount")
                        .HasColumnType("money");

                    b.HasKey("PaymentId");

                    b.HasIndex("CustomerBookingId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("Event_Management.Models.Supplier", b =>
                {
                    b.Property<int>("SupplierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SupplierId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("SupplierName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("SupplyType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("SupplierId");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("Event_Management.Models.Venue", b =>
                {
                    b.Property<int>("VenueId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VenueId"));

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<decimal>("DailyRent")
                        .HasColumnType("money");

                    b.Property<bool>("IsEnlisted")
                        .HasColumnType("bit");

                    b.Property<string>("VenueAddress")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("VenueDescription")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("VenueName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VenueType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VenueId");

                    b.ToTable("Venues");
                });

            modelBuilder.Entity("Event_Management.Models.Worker", b =>
                {
                    b.Property<int>("WorkerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WorkerId"));

                    b.Property<bool>("ActiveStatus")
                        .HasColumnType("bit");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime>("JoinDate")
                        .HasColumnType("date");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("WorkerName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("WorkerId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Workers");
                });

            modelBuilder.Entity("Event_Management_System.Models.BillTable", b =>
                {
                    b.Property<int>("BillId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BillId"));

                    b.Property<int>("CustomerBookingId")
                        .HasColumnType("int");

                    b.Property<double>("GrandTotal")
                        .HasColumnType("float");

                    b.Property<double>("totalEquipmentBill")
                        .HasColumnType("float");

                    b.Property<double>("totalFoodBill")
                        .HasColumnType("float");

                    b.Property<double>("totalServicesBill")
                        .HasColumnType("float");

                    b.HasKey("BillId");

                    b.HasIndex("CustomerBookingId");

                    b.ToTable("BillTables");
                });

            modelBuilder.Entity("Event_Management_System.Models.BookingFood", b =>
                {
                    b.Property<int>("BookingFoodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookingFoodId"));

                    b.Property<int>("CustomerBookingId")
                        .HasColumnType("int");

                    b.Property<int>("FoodId")
                        .HasColumnType("int");

                    b.Property<double>("Quantity")
                        .HasColumnType("float");

                    b.HasKey("BookingFoodId");

                    b.HasIndex("CustomerBookingId");

                    b.HasIndex("FoodId");

                    b.ToTable("BookingFoods");
                });

            modelBuilder.Entity("Event_Management_System.Models.BookingServices", b =>
                {
                    b.Property<int>("BookingServicesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookingServicesId"));

                    b.Property<int>("CustomerBookingId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int?>("ServicesId")
                        .HasColumnType("int");

                    b.HasKey("BookingServicesId");

                    b.HasIndex("CustomerBookingId");

                    b.HasIndex("ServicesId");

                    b.ToTable("BookingServices");
                });

            modelBuilder.Entity("Event_Management_System.Models.Equipment", b =>
                {
                    b.Property<int>("EquipmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EquipmentId"));

                    b.Property<int>("AvailableQuantity")
                        .HasColumnType("int");

                    b.Property<string>("EquipmentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("UnitPricePerDay")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("EquipmentId");

                    b.ToTable("Equipment");
                });

            modelBuilder.Entity("Event_Management_System.Models.EquipmentBooking", b =>
                {
                    b.Property<int>("EquipmentBookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EquipmentBookingId"));

                    b.Property<int>("CustomerBookingId")
                        .HasColumnType("int");

                    b.Property<int>("DemandQuantity")
                        .HasColumnType("int");

                    b.Property<int>("EquipmentId")
                        .HasColumnType("int");

                    b.HasKey("EquipmentBookingId");

                    b.HasIndex("CustomerBookingId");

                    b.HasIndex("EquipmentId");

                    b.ToTable("EquipmentBookings");
                });

            modelBuilder.Entity("Event_Management_System.Models.FoodType", b =>
                {
                    b.Property<int>("FoodTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FoodTypeId"));

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("FoodTypeId");

                    b.ToTable("FoodTypes");
                });

            modelBuilder.Entity("Event_Management_System.Models.RentalEquipment", b =>
                {
                    b.Property<int>("RentalEquipmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RentalEquipmentId"));

                    b.Property<string>("EquipmentName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<DateTime>("RentalDate")
                        .HasColumnType("date");

                    b.Property<DateTime>("ReturnDate")
                        .HasColumnType("date");

                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("money");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("money");

                    b.HasKey("RentalEquipmentId");

                    b.HasIndex("SupplierId");

                    b.ToTable("RentalEquipment");
                });

            modelBuilder.Entity("Event_Management_System.Models.ServiceType", b =>
                {
                    b.Property<int>("ServiceTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ServiceTypeId"));

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ServiceTypeId");

                    b.ToTable("ServiceTypes");
                });

            modelBuilder.Entity("Event_Management_System.Models.Services", b =>
                {
                    b.Property<int?>("ServicesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("ServicesId"));

                    b.Property<int>("ServiceTypeId")
                        .HasColumnType("int");

                    b.Property<double>("UnitPrice")
                        .HasMaxLength(50)
                        .HasColumnType("float");

                    b.HasKey("ServicesId");

                    b.HasIndex("ServiceTypeId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("Event_Management.Models.Allowcation", b =>
                {
                    b.HasOne("Event_Management.Models.CustomerBooking", "CustomerBooking")
                        .WithMany()
                        .HasForeignKey("CustomerBookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Event_Management.Models.Employee", "Employee")
                        .WithMany("Allowcations")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Event_Management.Models.Worker", "Worker")
                        .WithMany("Allowcations")
                        .HasForeignKey("WorkerId");

                    b.Navigation("CustomerBooking");

                    b.Navigation("Employee");

                    b.Navigation("Worker");
                });

            modelBuilder.Entity("Event_Management.Models.CustomerBooking", b =>
                {
                    b.HasOne("Event_Management.Models.CustomerRegistration", "CustomerRegistration")
                        .WithMany("CustomerBookings")
                        .HasForeignKey("CustomerRegistrationCustomerId");

                    b.HasOne("Event_Management_System.Models.Equipment", "Equipment")
                        .WithMany("CustomerBookings")
                        .HasForeignKey("EquipmentId");

                    b.HasOne("Event_Management.Models.Event", "Event")
                        .WithMany("CustomerBookings")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Event_Management.Models.Food", "Food")
                        .WithMany("CustomerBookings")
                        .HasForeignKey("FoodId");

                    b.HasOne("Event_Management_System.Models.Services", "Services")
                        .WithMany("CustomerBookings")
                        .HasForeignKey("ServicesId");

                    b.HasOne("Event_Management.Models.Venue", "Venue")
                        .WithMany("CustomerBookings")
                        .HasForeignKey("VenueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CustomerRegistration");

                    b.Navigation("Equipment");

                    b.Navigation("Event");

                    b.Navigation("Food");

                    b.Navigation("Services");

                    b.Navigation("Venue");
                });

            modelBuilder.Entity("Event_Management.Models.Employee", b =>
                {
                    b.HasOne("Event_Management.Models.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Event_Management.Models.Feedback", b =>
                {
                    b.HasOne("Event_Management.Models.CustomerRegistration", "CustomerRegistration")
                        .WithMany("Feedbacks")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CustomerRegistration");
                });

            modelBuilder.Entity("Event_Management.Models.Food", b =>
                {
                    b.HasOne("Event_Management_System.Models.FoodType", "FoodType")
                        .WithMany("Foods")
                        .HasForeignKey("FoodTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FoodType");
                });

            modelBuilder.Entity("Event_Management.Models.LogIn", b =>
                {
                    b.HasOne("Event_Management.Models.CustomerRegistration", "CustomerRegistration")
                        .WithMany("LogIns")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CustomerRegistration");
                });

            modelBuilder.Entity("Event_Management.Models.Order", b =>
                {
                    b.HasOne("Event_Management.Models.Supplier", "Supplier")
                        .WithMany("Orders")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("Event_Management.Models.Payment", b =>
                {
                    b.HasOne("Event_Management.Models.CustomerBooking", "CustomerBooking")
                        .WithMany("Payment")
                        .HasForeignKey("CustomerBookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CustomerBooking");
                });

            modelBuilder.Entity("Event_Management.Models.Worker", b =>
                {
                    b.HasOne("Event_Management.Models.Department", "Department")
                        .WithMany("workers")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Event_Management_System.Models.BillTable", b =>
                {
                    b.HasOne("Event_Management.Models.CustomerBooking", "CustomerBooking")
                        .WithMany("BillTables")
                        .HasForeignKey("CustomerBookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CustomerBooking");
                });

            modelBuilder.Entity("Event_Management_System.Models.BookingFood", b =>
                {
                    b.HasOne("Event_Management.Models.CustomerBooking", "CustomerBooking")
                        .WithMany("BookingFood")
                        .HasForeignKey("CustomerBookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Event_Management.Models.Food", "Food")
                        .WithMany("BookingFood")
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CustomerBooking");

                    b.Navigation("Food");
                });

            modelBuilder.Entity("Event_Management_System.Models.BookingServices", b =>
                {
                    b.HasOne("Event_Management.Models.CustomerBooking", "CustomerBooking")
                        .WithMany("BookingServices")
                        .HasForeignKey("CustomerBookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Event_Management_System.Models.Services", "Services")
                        .WithMany("BookingServices")
                        .HasForeignKey("ServicesId");

                    b.Navigation("CustomerBooking");

                    b.Navigation("Services");
                });

            modelBuilder.Entity("Event_Management_System.Models.EquipmentBooking", b =>
                {
                    b.HasOne("Event_Management.Models.CustomerBooking", "CustomerBooking")
                        .WithMany("EquipmentBookings")
                        .HasForeignKey("CustomerBookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Event_Management_System.Models.Equipment", "Equipment")
                        .WithMany("EquipmentBookings")
                        .HasForeignKey("EquipmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CustomerBooking");

                    b.Navigation("Equipment");
                });

            modelBuilder.Entity("Event_Management_System.Models.RentalEquipment", b =>
                {
                    b.HasOne("Event_Management.Models.Supplier", "Supplier")
                        .WithMany("RentalEquipment")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("Event_Management_System.Models.Services", b =>
                {
                    b.HasOne("Event_Management_System.Models.ServiceType", "ServiceType")
                        .WithMany("Services")
                        .HasForeignKey("ServiceTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ServiceType");
                });

            modelBuilder.Entity("Event_Management.Models.CustomerBooking", b =>
                {
                    b.Navigation("BillTables");

                    b.Navigation("BookingFood");

                    b.Navigation("BookingServices");

                    b.Navigation("EquipmentBookings");

                    b.Navigation("Payment");
                });

            modelBuilder.Entity("Event_Management.Models.CustomerRegistration", b =>
                {
                    b.Navigation("CustomerBookings");

                    b.Navigation("Feedbacks");

                    b.Navigation("LogIns");
                });

            modelBuilder.Entity("Event_Management.Models.Department", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("workers");
                });

            modelBuilder.Entity("Event_Management.Models.Employee", b =>
                {
                    b.Navigation("Allowcations");
                });

            modelBuilder.Entity("Event_Management.Models.Event", b =>
                {
                    b.Navigation("CustomerBookings");
                });

            modelBuilder.Entity("Event_Management.Models.Food", b =>
                {
                    b.Navigation("BookingFood");

                    b.Navigation("CustomerBookings");
                });

            modelBuilder.Entity("Event_Management.Models.Supplier", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("RentalEquipment");
                });

            modelBuilder.Entity("Event_Management.Models.Venue", b =>
                {
                    b.Navigation("CustomerBookings");
                });

            modelBuilder.Entity("Event_Management.Models.Worker", b =>
                {
                    b.Navigation("Allowcations");
                });

            modelBuilder.Entity("Event_Management_System.Models.Equipment", b =>
                {
                    b.Navigation("CustomerBookings");

                    b.Navigation("EquipmentBookings");
                });

            modelBuilder.Entity("Event_Management_System.Models.FoodType", b =>
                {
                    b.Navigation("Foods");
                });

            modelBuilder.Entity("Event_Management_System.Models.ServiceType", b =>
                {
                    b.Navigation("Services");
                });

            modelBuilder.Entity("Event_Management_System.Models.Services", b =>
                {
                    b.Navigation("BookingServices");

                    b.Navigation("CustomerBookings");
                });
#pragma warning restore 612, 618
        }
    }
}
