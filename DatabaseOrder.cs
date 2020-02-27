// using System.Runtime.Intrinsics.X86;
// using System.Net;
// using System;
// using System.Net.Http;
// using System.Threading.Tasks;
// using Npgsql;
// using refactorytryout.Models;
// using System.Linq;
// using System.Collections.Generic;
// using Microsoft.AspNetCore.JsonPatch;
// using Microsoft.AspNetCore.Mvc;

// namespace refactorytryout
// {
//     public interface IDatabaseOrder{
//         List<Orders> readOrder();
//         int createOrder(Orders order);
//         Orders readByID(int id);
//         void updateOrder(int id, [FromBody]JsonPatchDocument<Orders> data);
//         void deleteOrder(int id);
//     }   
//     public class DatabaseOrder : IDatabaseOrder
//     {
//          NpgsqlConnection _connection;
         
//         //  private string guid { get; set; }

//         public DatabaseOrder(NpgsqlConnection connection){

//             _connection = connection;
//             _connection.Open();
//         }

//         List<Orders> readOrder(){
//             var command = _connection.CreateCommand();
//             command.CommandText = "SELECT * FROM Order";
//             var result = command.ExecuteReader();
//             var Order = new List<Orders>();
//             while (result.Read())
//                 Order.Add(new Orders() { 
//                     Id = (int)result[0], 
//                     User_id = (int)result[1], 
//                     Status = (Order_status)result[2] ,
//                     Driver_id = (int)result[3], 
//                     Created_at = (DateTime)result[4] ,
//                     Updated_at = (DateTime)result[5] ,
//                 });
//             _connection.Close();
//             return Order;
//         }
//         int createOrder(Orders order){
//             var command = _connection.CreateCommand();
//             command.CommandText = 
//             "INSERT INTO Order (User_id, Status, Driver_id, Created_at, Updated_at) VALUES (@User_id , @Status, @Driver_id, current_timestamp, current_timestamp) RETURNING id";
//             command.Parameters.AddWithValue("@User_id", order.User_id);
//             command.Parameters.AddWithValue("@Status", order.Status);
//             command.Parameters.AddWithValue("@Driver_id", order.Driver_id);

//             command.Prepare();
//             var result = command.ExecuteScalar();
//             _connection.Close();

//             return (int)result;
//         }
//         Orders readByID(int id){
//             var command = _connection.CreateCommand();

//             command.CommandText = $"SELECT * FROM Posts WHERE id = @id";
//             command.Parameters.AddWithValue("@id", id);
//             var result = command.ExecuteReader();
//             result.Read();

//             var orderId = new Orders(){
//                     Id = (int)result[0], 
//                     User_id = (int)result[1], 
//                     Status = (Order_status)result[2] ,
//                     Driver_id = (int)result[3], 
//                     Created_at = (DateTime)result[4] ,
//                     Updated_at = (DateTime)result[5] 
//             };
//             _connection.Close();
//             return orderId;
//         }
//         void updateOrder(int id, [FromBody]JsonPatchDocument<Orders> data){
//             var command = _connection.CreateCommand();
//             var orderId = readByID(id);
//             _connection.Open();

//             data.ApplyTo(orderId);

//             command.CommandText = $"UPDATE Order SET(User_id, Status, Driver_id, Created_at, Updated_at) = (@User_id , @Status, @Driver_id, @Created_at, current_timestamp) WHERE id = {id}";
//             command.Parameters.AddWithValue("@User_id", orderId.User_id);
//             command.Parameters.AddWithValue("@Status", orderId.Status);
//             command.Parameters.AddWithValue("@Driver_id", orderId.Driver_id);
//             command.Parameters.AddWithValue("@Created_at", orderId.Created_at);

//             command.ExecuteNonQuery();
//             _connection.Close();
//         }
//         void deleteOrder(int id){
//             var command = _connection.CreateCommand();

//             command.CommandText = $"DELETE FROM posts WHERE id = {id}";

//             var result = command.ExecuteNonQuery();
//             _connection.Close();
//         }
//     }
// }