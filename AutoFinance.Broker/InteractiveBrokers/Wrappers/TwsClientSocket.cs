﻿// Licensed under the Apache License, Version 2.0.

namespace AutoFinance.Broker.InteractiveBrokers.Wrappers
{
    using System.Collections.Generic;
    using IBApi;

    /// <summary>
    /// This class is a wrapper around the TwsClientSocket.
    /// </summary>
    internal class TwsClientSocket : ITwsClientSocket
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TwsClientSocket"/> class.
        /// </summary>
        /// <param name="eClientSocket">The client socket that this class wraps</param>
        public TwsClientSocket(EClientSocket eClientSocket)
        {
            this.EClientSocket = eClientSocket;
        }

        /// <summary>
        /// Gets the TWS socket connection
        /// </summary>
        public EClientSocket EClientSocket
        {
            get;
            private set;
        }

        /// <summary>
        /// Connect to the socket
        /// </summary>
        /// <param name="host">The host</param>
        /// <param name="port">The port</param>
        /// <param name="clientId">The client Id</param>
        public void Connect(string host, int port, int clientId)
        {
            this.EClientSocket.eConnect(host, port, clientId);
        }

        /// <summary>
        /// Disconnect from the socket
        /// </summary>
        public void Disconnect()
        {
            this.EClientSocket.eDisconnect();
        }

        /// <summary>
        /// Send an order to TWS
        /// </summary>
        /// <param name="orderId">The order Id</param>
        /// <param name="contract">The contract</param>
        /// <param name="order">The order</param>
        public void PlaceOrder(int orderId, Contract contract, Order order)
        {
            this.EClientSocket.placeOrder(orderId, contract, order);
        }

        /// <summary>
        /// Cancel an order on TWS
        /// </summary>
        /// <param name="orderId">The order Id to cancel</param>
        public void CancelOrder(int orderId)
        {
            this.EClientSocket.cancelOrder(orderId);
        }

        /// <summary>
        /// Request contract details from TWS
        /// </summary>
        /// <param name="requestId">The request Id</param>
        /// <param name="contract">The contract</param>
        public void ReqContractDetails(int requestId, Contract contract)
        {
            this.EClientSocket.reqContractDetails(requestId, contract);
        }

        /// <summary>
        /// Request account details from TWS
        /// </summary>
        /// <param name="subscribe">Subscribe the the stream</param>
        /// <param name="accountCode">The account of the details requested</param>
        public void ReqAccountDetails(bool subscribe, string accountCode)
        {
            this.EClientSocket.reqAccountUpdates(subscribe, accountCode);
        }

        /// <summary>
        /// Request historical data from TWS
        /// </summary>
        /// <param name="requestId">The ticker Id</param>
        /// <param name="contract">The contract</param>
        /// <param name="endDateTime">The end time</param>
        /// <param name="durationString">The duration string</param>
        /// <param name="barSizeSetting">The bar size setting</param>
        /// <param name="whatToShow">The things to show (?)</param>
        /// <param name="useRTH">Whether to use regular trading hours</param>
        /// <param name="formatDate">Whether to format the date</param>
        /// <param name="chartOptions">The chart options</param>
        /// <param name="keepUpToDate">Keep the chart up to date or not</param>
        public void ReqHistoricalData(int requestId, Contract contract, string endDateTime, string durationString, string barSizeSetting, string whatToShow, int useRTH, int formatDate, List<TagValue> chartOptions, bool keepUpToDate = false)
        {
            this.EClientSocket.reqHistoricalData(requestId, contract, endDateTime, durationString, barSizeSetting, whatToShow, useRTH, formatDate, keepUpToDate, chartOptions);
        }

        /// <summary>
        /// Request realtime data from TWS
        /// </summary>
        /// <param name="tickerId">The request Id</param>
        /// <param name="contract">The contract</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="whatToShow">The things to show. "BID", "ASK", or "MIDPOINT"</param>
        /// <param name="useRTH">Whether to use regular trading hours</param>
        /// <param name="realtimeBarOptions">The realtime bar options</param>
        public void ReqRealtimeBars(int tickerId, Contract contract, int barSize, string whatToShow, bool useRTH, List<TagValue> realtimeBarOptions)
        {
            this.EClientSocket.reqRealTimeBars(tickerId, contract, barSize, whatToShow, useRTH, realtimeBarOptions);
        }

        /// <summary>
        /// Sends a message to TWS telling it to cancel a real-time bar subscription
        /// </summary>
        /// <param name="requestId">The request Id of the subscription for which to cancel</param>
        public void CancelRealtimeBars(int requestId)
        {
            this.EClientSocket.cancelRealTimeBars(requestId);
        }

        /// <summary>
        /// Sends a message to TWS telling it to send position information through the socket.
        /// </summary>
        public void RequestPositions()
        {
            this.EClientSocket.reqPositions();
        }

        /// <summary>
        /// Sends a message to TWS telling it to send execution information through the socket.
        /// </summary>
        /// <param name="requestId">The request Id</param>
        public void RequestExecutions(int requestId)
        {
            this.EClientSocket.reqExecutions(requestId, new ExecutionFilter());
        }

        /// <summary>
        /// Request the open orders
        /// </summary>
        public void RequestAllOpenOrders()
        {
            this.EClientSocket.reqAllOpenOrders();
        }

        /// <summary>
        /// Request market data (for news as well)
        /// </summary>
        /// <param name="requestId">The request</param>
        /// <param name="contract">The contract</param>
        /// <param name="genericTickList">The generic tick list</param>
        /// <param name="snapshot">The snapshot</param>
        /// <param name="regulatorySnaphsot">The regulatory snapshot</param>
        /// <param name="marketDataOptions">The market data options</param>
        public void RequestMarketData(int requestId, Contract contract, string genericTickList, bool snapshot, bool regulatorySnaphsot, List<TagValue> marketDataOptions)
        {
            this.EClientSocket.reqMktData(requestId, contract, genericTickList, snapshot, regulatorySnaphsot, marketDataOptions);
        }

        /// <summary>
        /// Request option chain details
        /// </summary>
        /// <param name="reqId">The request Id</param>
        /// <param name="underlyingSymbol">The underlying symbol</param>
        /// <param name="futFopExchange">The exchange</param>
        /// <param name="underlyingSecType">The underlying security type</param>
        /// <param name="underlyingConId">The underlying contract id</param>
        public void RequestSecurityDefinitionOptionParameters(int reqId, string underlyingSymbol, string futFopExchange, string underlyingSecType, int underlyingConId)
        {
            this.EClientSocket.reqSecDefOptParams(reqId, underlyingSymbol, futFopExchange, underlyingSecType, underlyingConId);
        }
    }
}
